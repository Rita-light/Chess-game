using System;
using System.Collections.Generic;

namespace Chess.Modèles
{
    public class Partie
    {
        private static int dernierID = 0;
        public int ID { get; private set; }
        public Plateau Plateau { get; private set; }
        public Joueur JoueurBlanc { get; private set; }
        public Joueur JoueurNoir { get; private set; }
        public Joueur JoueurActuel { get; private set; }
        public List<Coup> HistoriqueCoup { get; private set; }
        public bool EstTermine { get; private set; }
        public int PointBlanc { get; private set; }
        public int PointNoir { get; private set; }

        public Partie( Joueur joueurBlanc, Joueur joueurNoir)
        {
            ID = ++dernierID;
            if (joueurBlanc == null)
                throw new ArgumentNullException(nameof(joueurBlanc));
            if (joueurNoir == null)
                throw new ArgumentNullException(nameof(joueurNoir));

            JoueurBlanc = joueurBlanc;
            JoueurNoir = joueurNoir;
            JoueurActuel = joueurBlanc;
            HistoriqueCoup = new List<Coup>();
            EstTermine = false;
            PointBlanc = 0;
            PointNoir = 0;
            Plateau = new Plateau();
        }

        public void InitialiserPartie(Joueur joueurBlanc, Joueur joueurNoir)
        {
            throw new System.NotImplementedException();
            // TODO: Réinitialiser les scores, l'historique des coups et assigner les joueurs.
        }

        public void InitialiserPlateau()
        {
            throw new System.NotImplementedException();
            // TODO: Mettre en place le plateau avec toutes les pièces à leur position initiale.
        }
        
        

        public bool ExecuterCoup(Coup coup)
        {
            Boolean coupValide = Plateau.EstCoupValide(coup);
            if (coupValide)
            {
                Plateau.AppliquerCoup(coup);
                return true;
            }

            return false;
        }

        public void ChangerTour()
        {
            throw new System.NotImplementedException();
            // TODO: Alterner JoueurActuel entre JoueurBlanc et JoueurNoir.
        }

        public void AbandonnerPartie(Joueur joueur)
        {
            throw new System.NotImplementedException();
        }

        public void EstNulle()
        {
            throw new System.NotImplementedException();
            // TODO: Implémenter la vérification des conditions de match nul.
        }

        public void TerminerPartie()
        {
            throw new System.NotImplementedException();
            // TODO: Finaliser la partie en marquant EstTermine, sauvegarder les scores dans un fichier, etc.
        }

        public override string ToString()
        {
            return $"Partie {ID} : {JoueurBlanc} vs {JoueurNoir} - Tour actuel : {JoueurActuel}, Terminé : {EstTermine}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Partie))
                return false;

            Partie autre = (Partie)obj;
            return ID == autre.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
