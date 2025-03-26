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
            this.gestionnaire = new Gestionnaire(); 
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

        public void AjouterJoueur(string nom)
        {
            if(string.IsNullOrWhiteSpace(nom)){
                throw new ArgumentException("Le nom du joueur ne peut pas être vide.");
            }
            gestionnaire.listJoueurs.Add(new Joueur(nom));
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
        
        
        public String ObtenirPlateauActuel()
        {
            
            return gestionnaire.ObtenirPlateauActuel();
        }

        public Boolean jouerCoup(int departX, int departY, int destinationX, int destinationY, int partieID)
        {
            
            return gestionnaire.jouerCoup( departX, departY,  destinationX, destinationY, partieID);
        }
        
        public void CreerNouveauJoueur(String nomJoueur)
        {
            gestionnaire.CreerNouveauJoueur(nomJoueur);
        }
    }
}