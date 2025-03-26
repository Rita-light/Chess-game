using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    public partial class SelectionnerJoueurGUI : Form
    {
        private FenetrePrincipale fenetrePrincipale;
        public SelectionnerJoueurGUI(FenetrePrincipale fenetrePrincipale)
        {
            InitializeComponent();
            this.fenetrePrincipale = fenetrePrincipale;
            
            // Récupère la liste des joueurs depuis FenetrePrincipale
            List<String> joueurs = fenetrePrincipale.ObtenirListeJoueurs();

            // Afficher la liste des joueurs dans la ListView
            AfficherJoueursDansListView(joueurs);
            
        }
        
        // Méthode pour afficher les joueurs dans la ListView
        private void AfficherJoueursDansListView(List<string> lignes)
        {
            lstJoueurs.Items.Clear(); // Nettoie d'abord la ListView pour éviter les doublons

            foreach (var ligne in lignes)
            {
                try
                {
                    var parts = ligne.Split(';');

                    if (parts.Length != 6) // Vérifie qu'il y a exactement 6 parties
                    {
                        throw new FormatException($"Ligne mal formatée : {ligne}");
                    }
                    // Créer un nouvel élément pour la ListView avec les informations du joueur
                    var item = new ListViewItem(parts[0]); // JoueurID
                    item.SubItems.Add(parts[1]);          // Nom
                    lstJoueurs.Items.Add(item);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erreur de format : {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors du traitement : {ex.Message}");
                }
            }
        }
        
        private void NouveauJoueur_Click(object sender, EventArgs e)
        {
            fenetrePrincipale.CreerNouveauJoueur(newJoueur.Text);
            AfficherJoueursDansListView(fenetrePrincipale.ObtenirListeJoueurs());
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void btnNouvellePart_Click(object sender, EventArgs e)
        {
            // Récupérer les joueurs sélectionnés dans la ListView
            var joueursSelectionnes = lstJoueurs.SelectedItems;

            // Vérifier que deux joueurs sont sélectionnés
            if (joueursSelectionnes.Count != 2)
            {
                MessageBox.Show("Erreur : Vous devez sélectionner exactement deux joueurs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Extraire les joueurs depuis les éléments sélectionnés
            var joueurs = new List<String>();
            foreach (ListViewItem item in joueursSelectionnes)
            {
                var joueurID = int.Parse(item.SubItems[0].Text);
                
                // Recherche de la chaîne correspondant au joueur via son ID dans la liste principale
                var ligneJoueur = fenetrePrincipale.ObtenirListeJoueurs()
                            .FirstOrDefault(ligne => ligne.StartsWith($"{joueurID};"));

                if (!string.IsNullOrEmpty(ligneJoueur))
                {
                    joueurs.Add(ligneJoueur); // Ajout à la liste des joueurs sélectionnés
                }
                
            }
            
            // Fermer la fenêtre actuelle
            this.Close();
            
            // Transmettre les joueurs à FenetrePrincipale
            fenetrePrincipale.CreerNouvellePartie(joueurs);
            
        }
    }
}