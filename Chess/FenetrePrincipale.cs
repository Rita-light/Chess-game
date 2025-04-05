using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chess.Controlleurs;

namespace Chess
{
    public partial class FenetrePrincipale : Form
    {
        
        // Attributs pour le contrôleur
        private JeuController controller;

        // Attributs pour les fenêtres secondaires
        private StatistiqueGUI statistiqueGUI;
        private SelectionnerJoueurGUI selectionnerJoueurGUI;
        private List<PlateauGUI> listePlateaux;
        public PlateauGUI plateauGuiActuel;
        public FenetrePrincipale(JeuController controller)
        {
            InitializeComponent();
            
            this.controller = controller; // Enregistre le contrôleur
            this.statistiqueGUI = new StatistiqueGUI(this); // Crée l'instance de la fenêtre StatistiqueGUI
            this.selectionnerJoueurGUI = new SelectionnerJoueurGUI(this); // Initialise avec les joueurs
            this.listePlateaux = new List<PlateauGUI>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectionnerJoueurGUI.ShowDialog();
        }
        
        public List<String> ObtenirListeJoueurs()
        {
            return controller.ObtenirListeJoueurs();
        }

        public List<String> ObtenirListeScores()
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
        
        public void CreerNouvellePartie(List<String> joueurs)
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
             plateauGuiActuel = new PlateauGUI(this, partieID);
             listePlateaux.Add(plateauGuiActuel);
             plateauGuiActuel.Show();
        }

        public (String, String) ObtenirNomJoueur()
        {
            return controller.ObtenirNomJoueur();
        }
        
        public String ObtenirPlateauActuel(int partieID)
        {
            return controller.ObtenirPlateauActuel(partieID);
        }

        public Boolean jouerCoup(int departX, int departY, int destinationX, int destinationY, int partieID)
        {
           return controller.jouerCoup( departX,  departY,  destinationX,  destinationY, partieID);
        }

        public void CreerNouveauJoueur(String nomJoueur)
        {
            controller.CreerNouveauJoueur(nomJoueur);
        }
        
        public int ObtenirIdPartie()
        {
            return controller.ObtenirId();
        }
      
        
        public void AfficherMessageErreur(String message)
        {
            int indexPlateau = TrouverIndexPlateauParPartieID(ObtenirIdPartie());
            if (indexPlateau >= 0 && indexPlateau < listePlateaux.Count)
            {
                listePlateaux[indexPlateau].AfficherMessageErreur(message);
            }
            
        }
        public void AfficherMessage(String message)
        {
            int indexPlateau = TrouverIndexPlateauParPartieID(ObtenirIdPartie());
            if (indexPlateau >= 0 && indexPlateau < listePlateaux.Count)
            {
                listePlateaux[indexPlateau].AfficherMessage(message);
            }
            
        }
        
        public int TrouverIndexPlateauParPartieID(int partieID)
        {
            for (int i = 0; i < listePlateaux.Count; i++)
            {
                if (listePlateaux[i].PartieID == partieID)
                {
                    return i; // On a trouvé le bon plateau
                }
            }

            return -1; // Si aucun plateau ne correspond
        }

        
        private void QuitterProgramme()
            {
                // Demande de confirmation avant de fermer
                DialogResult resultat = MessageBox.Show(
                    "Voulez-vous vraiment fermer le programme ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Si l'utilisateur clique sur "Non", annulez la fermeture
                if (resultat == DialogResult.Yes)
                {          
                    controller.QuitterProgramme();
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Fermeture annulée.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Exécutez votre logique personnalisée ici avant de fermer
                    
                }
            }

        public (int, int) ObtenirPoint()
        {
            return controller.ObtenirPoint();
        }
        public bool AbandonnerPartie(int joeurID, int partieID)
        {
            // Signaler l'abandon au contrôleur
            return controller.AbandonnerPartie(joeurID, partieID);
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            QuitterProgramme();
        }
    }
    
}