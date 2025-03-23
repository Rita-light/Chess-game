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
            this.plateauGUI = new PlateauGUI(this); 
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
            var nouvellePartie = new Partie(joueurs[0], joueurs[1]);

            // Enregistrer la nouvelle partie dans le gestionnaire
            AjouterNouvellePartie(nouvellePartie);

            // Définir la partie actuelle
            DefinirPartieActuelle(nouvellePartie);

            // Ouvrir PlateauGUI
            plateauGUI.Show();
        }

        
        public void AjouterNouvellePartie(Partie partie)
        {
            controller.AjouterPartie(partie);
        }
        
        public void DefinirPartieActuelle(Partie partie)
        {
            controller.DefinirPartieActuelle(partie);
        }
        
        public Partie ObtenirPartieActuelle()
        {
            return controller.ObtenirPartieActuelle();
        }
        
        public Plateau ObtenirPlateauActuel()
        {
            return controller.ObtenirPlateauActuel();
        }

        public Boolean jouerCoup(Position depart, Position destination)
        {
           return controller.jouerCoup(depart, destination);
        }



    }
}