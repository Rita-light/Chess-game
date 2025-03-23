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
        public List<Joueur> ObtenirListeJoueurs()
        {
            return gestionnaire.listJoueurs;
        }

        public List<Score> ObtenirListeScore()
        {
            return gestionnaire.listeScores;
        }

        public void AjouterJoueur(string nom)
        {
            if(string.IsNullOrWhiteSpace(nom)){
                throw new ArgumentException("Le nom du joueur ne peut pas être vide.");
            }
            gestionnaire.listJoueurs.Add(new Joueur(nom));
        }
        
        public void AjouterPartie(Partie partie)
        {
            gestionnaire.AjouterPartie(partie);
        }
        
        public void DefinirPartieActuelle(Partie partie)
        {
            gestionnaire.partieActuelle = partie;
        }
        
        public Partie ObtenirPartieActuelle()
        {
            if (gestionnaire.partieActuelle == null)
            {
                throw new InvalidOperationException("Aucune partie actuelle n'est définie.");
            }
            return gestionnaire.partieActuelle;
        }



    }
}