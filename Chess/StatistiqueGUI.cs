using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    public partial class StatistiqueGUI : Form
    {
        private FenetrePrincipale fenetrePrincipale;
        public StatistiqueGUI(FenetrePrincipale fenetrePrincipale)
        {
            InitializeComponent();
            this.fenetrePrincipale = fenetrePrincipale;
            
            // Récupère la liste des joueurs depuis FenetrePrincipale
            List<String> scores = fenetrePrincipale.ObtenirListeScores();
            
            afficherJoueurScore(scores);
        }

        private void afficherJoueurScore(List<string> scores)
        {
            // Effacer les colonnes actuelles de la table
            dataScores.Columns.Clear();

            var donnees = new List<object>();

            foreach (var ligne in scores)
            {
                try
                {
                    // Découper la chaîne en parties (on suppose le format "JoueurID;Nom;Victoire;Défaite;PartNulle;Classement;Points")
                    var parts = ligne.Split(';');

                    if (parts.Length != 7) // S'assurer qu'il y a exactement 7 parties
                    {
                        throw new FormatException($"Ligne mal formatée : {ligne}");
                    }
                    // Ajouter les données pour affichage (aucun besoin de classe Score ici)
                    donnees.Add(new
                    {
                        JoueurID = int.Parse(parts[0]),  // JoueurID
                        Nom = parts[1],  
                        Points = int.Parse(parts[6]),   // Points// Nom
                        Classement = int.Parse(parts[5])// Classement
                    });
                }
                catch (FormatException ex)
                {
                    // Gérer les erreurs de format (log ou traitement silencieux)
                    Console.WriteLine($"Erreur de format : {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Gérer toute autre erreur éventuelle
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
            }

            // Assigner les données au DataGridView
            dataScores.DataSource = donnees;
        }


        private void dataScores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifie qu'on a bien cliqué sur une ligne (pas l'entête)
            if (e.RowIndex >= 0)
            {
                Console.WriteLine("Cell content click");
                try
                {
                    // Récupère la ligne cliquée
                    DataGridViewRow ligne = dataScores.Rows[e.RowIndex];

                    // Récupère l'ID du joueur à partir de la cellule
                    int joueurID = Convert.ToInt32(ligne.Cells["JoueurID"].Value);

                    // Recherche du score correspondant au joueur
                    // Recherche de la chaîne correspondant au joueur via son ID dans la liste des scores
                    string ligneScore = fenetrePrincipale.ObtenirListeScores()
                        .FirstOrDefault(s => s.StartsWith($"{joueurID};"));


                    if (!string.IsNullOrEmpty(ligneScore))
                    {
                        // Analyse la chaîne pour récupérer les données du joueur et son score
                        var parts = ligneScore.Split(';');
                        if (parts.Length != 7) // Vérifie qu'on a bien toutes les informations nécessaires
                        {
                            throw new FormatException($"La ligne de score est mal formatée : {ligneScore}");
                        }

                        // Récupère les informations
                        string nom = parts[1];
                        int victoire = int.Parse(parts[2]);
                        int defaite = int.Parse(parts[3]);
                        int partNulle = int.Parse(parts[4]);
                        int classement = int.Parse(parts[5]);
                        int points = int.Parse(parts[6]);
                        
                        // Met à jour les labels avec les infos du joueur
                        lblNom.Text = $"{nom}";
                        lblVictoire.Text = $"{victoire}";
                        lblDefaite.Text = $"{defaite}";
                        lblNull.Text = $"{partNulle}";
                        lblClassement.Text = $"{classement}";
                    }
                    else
                    {
                        MessageBox.Show("Aucun score trouvé pour ce joueur.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la sélection : " + ex.Message);
                }
            }
        }

    }
}