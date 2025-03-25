using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chess.Controlleurs;
using Chess.Modèles;


namespace Chess
{
    public partial class FenetrePrincipale : Form
    {
        
        // Attributs pour le contrôleur
        private JeuController controller;

        // Attributs pour les fenêtres secondaires
        private StatistiqueGUI statistiqueGUI;
        private SelectionnerJoueurGUI selectionnerJoueurGUI;
        private PlateauGUI plateauGUI;
        public FenetrePrincipale(JeuController controller)
        {
            InitializeComponent();
            
            this.controller = controller; // Enregistre le contrôleur
            this.statistiqueGUI = new StatistiqueGUI(this); // Crée l'instance de la fenêtre StatistiqueGUI
            this.selectionnerJoueurGUI = new SelectionnerJoueurGUI(this); // Initialise avec les joueurs
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectionnerJoueurGUI.ShowDialog();
        }
        
        public List<Joueur> ObtenirListeJoueurs()
        {
            return controller.ObtenirListeJoueurs();
        }

        public List<Score> ObtenirListeScores()
        {
            return controller.ObtenirListeScore();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            statistiqueGUI.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectionnerJoueurGUI.ShowDialog();
        }
        
        public void CreerNouvellePartie(List<Joueur> joueurs)
        {
           // Vérifier qu'il y a exactement deux joueurs
            if (joueurs.Count != 2)
            {
                MessageBox.Show("Erreur : Vous devez fournir exactement deux joueurs pour créer une partie.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Créer une nouvelle partie
            int partieID = controller.CreerNouvellePartie(joueurs);
            
            // Ouvrir PlateauGUI pour cette partie
            new PlateauGUI(this, partieID).Show();
            
        }

        public (String, String) ObtenirNomJoueur()
        {
            return controller.ObtenirNomJoueur();
        }
        
        public String ObtenirPlateauActuel()
        {
            return controller.ObtenirPlateauActuel();
        }

        public Boolean jouerCoup(int departX, int departY, int destinationX, int destinationY, int partieID)
        {
           return controller.jouerCoup( departX,  departY,  destinationX,  destinationY, partieID);
        }

        public void CreerNouveauJoueur(String nomJoueur)
        {
            controller.CreerNouveauJoueur(nomJoueur);
        }
    }
}