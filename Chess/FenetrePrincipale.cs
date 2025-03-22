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
            this.plateauGUI = new PlateauGUI(); 
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
    }
}