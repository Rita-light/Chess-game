using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chess.Modèles;

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
            List<Score> scores = fenetrePrincipale.ObtenirListeScores();
            
            afficherJoueurScore(scores);
        }

        private void afficherJoueurScore(List<Score> scores)
        {
            
            dataScores.Columns.Clear();
            
            var donnees = new List<Object>();
            foreach (var score in scores)
            {
                donnees.Add(new
                {
                    JoueurID = score.Joueur.JoueurID,
                    Nom = score.Joueur.Nom,
                    Points = score.Points,
                    Classement = score.Joueur.Classement,
                });
            }
            
            //afficher les données
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

                    // Récupère les autres infos depuis les cellules (facultatif)
                    string nom = ligne.Cells["Nom"].Value.ToString();

                    // Recherche du score correspondant au joueur
                    Score score = fenetrePrincipale.ObtenirListeScores()
                        .FirstOrDefault(s => s.Joueur != null && s.Joueur.JoueurID == joueurID);

                    if (score != null)
                    {
                        Console.WriteLine(score.ToString());
                    }
                    else
                    {
                        Console.WriteLine("erreur ici");
                    }
                    
                    if (score != null)
                    {
                        // Met à jour les labels avec les infos du joueur
                        lblNom.Text = $"{nom}";
                        lblVictoire.Text = $"{score.Joueur.Victoire}";
                        lblDefaite.Text = $"{score.Joueur.Defaite}";
                        lblNull.Text = $"{score.Joueur.PartNulle}";
                        lblClassement.Text = $"{score.Joueur.Classement}";
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