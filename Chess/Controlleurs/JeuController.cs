using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chess.Modèles;

namespace Chess.Controlleurs
{
    public class JeuController
    {
        
        private Gestionnaire gestionnaire;
        private FenetrePrincipale fenetrePrincipale;
        
        public JeuController()
        {
            this.gestionnaire = new Gestionnaire(this); 
            this.fenetrePrincipale = new FenetrePrincipale(this);  
        }

        public void DemarrerApplication()
        {
            // Affiche la fenêtre principale
            Application.Run(fenetrePrincipale);
        }
        
        // Méthodes de communication ou de gestion (ajoutées selon besoin)
        public List<String> ObtenirListeJoueurs()
        {
            return gestionnaire.ObtenirJoueurFormatString();
        }

        public List<String> ObtenirListeScore()
        {
            return gestionnaire.ObtenirScoresFormatString();
        }

        public int CreerNouvellePartie(List<String> joueurs)
        {
            int partieID = gestionnaire.CreerNouvellePartie(joueurs);
            return partieID;
        }

        public (String, String) ObtenirNomJoueur()
        {
            return gestionnaire.ObtenirNomJoueur();
        }
        
        public String ObtenirPlateauActuel(int partieID)
        {
            
            return gestionnaire.ObtenirPlateauActuel(partieID);
        }

        public Boolean jouerCoup(int departX, int departY, int destinationX, int destinationY, int partieID)
        {
            
            return gestionnaire.jouerCoup( departX, departY,  destinationX, destinationY, partieID);
        }
        
        public void CreerNouveauJoueur(String nomJoueur)
        {
            gestionnaire.CreerNouveauJoueur(nomJoueur);
        }
        public int ObtenirId()
        {
            return gestionnaire.ObtenirId();
        }
        public (int, int) ObtenirPoint()
        {
            return gestionnaire.ObtenirPoint();
        }
        
        public void AfficherMessageErreur(String message)
        {
             fenetrePrincipale.AfficherMessageErreur(message);
        }
        public void AfficherMessage(String message)
        {
            fenetrePrincipale.AfficherMessage(message);
        }
        public bool AbandonnerPartie(int joueurID, int partieID)
        {
            // Signaler l'abandon au contrôleur
            return gestionnaire.AbandonnerPartie(joueurID, partieID);
        }
        
        public void QuitterProgramme()
        {
            // Appeler la méthode dans le Gestionnaire pour vérifier les parties
            gestionnaire.QuitterProgramme();

            // Indiquer que le contrôleur a fini de gérer la fermeture
            MessageBox.Show("Toutes les interfaces ont été fermées.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}