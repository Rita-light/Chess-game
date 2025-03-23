using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chess.Modèles;

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
            List<Joueur> joueurs = fenetrePrincipale.ObtenirListeJoueurs();

            // Afficher la liste des joueurs dans la ListView
            AfficherJoueursDansListView(joueurs);
            
        }
        
        // Méthode pour afficher les joueurs dans la ListView
        private void AfficherJoueursDansListView(List<Joueur> joueurs)
        {
            lstJoueurs.Items.Clear(); // Nettoie d'abord la ListView pour éviter les doublons

            foreach (var joueur in joueurs)
            {
                // Ajouter les informations du joueur dans la ListView
                var item = new ListViewItem(joueur.JoueurID.ToString());
                item.SubItems.Add(joueur.Nom);
                lstJoueurs.Items.Add(item);
            }
        }


        private void NouveauJoueur_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
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
            var joueurs = new List<Joueur>();
            foreach (ListViewItem item in joueursSelectionnes)
            {
                var joueurID = int.Parse(item.SubItems[0].Text);
                var joueur = fenetrePrincipale.ObtenirListeJoueurs().Find(j => j.JoueurID == joueurID);
                if (joueur != null)
                {
                    joueurs.Add(joueur);
                }
            }
            // Fermer la fenêtre actuelle
            this.Close();
            
            // Transmettre les joueurs à FenetrePrincipale
            fenetrePrincipale.CreerNouvellePartie(joueurs);

            
        }
    }
}