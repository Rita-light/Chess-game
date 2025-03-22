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
            listViewJoueurs.Items.Clear(); // Nettoie d'abord la ListView pour éviter les doublons

            foreach (var joueur in joueurs)
            {
                // Ajouter les informations du joueur dans la ListView
                var item = new ListViewItem(joueur.JoueurID.ToString());
                item.SubItems.Add(joueur.Nom);
                listViewJoueurs.Items.Add(item);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void SelectionnerJoueurGUI_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}