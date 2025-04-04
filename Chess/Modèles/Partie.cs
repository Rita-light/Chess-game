using System;
using System.Collections.Generic;
using System.Threading;

namespace Chess.Modèles
{
    public class Partie
    {
        private static int dernierID = 0;
        private Gestionnaire gestionnaire;
        public int ID { get; private set; }
        public Plateau Plateau { get; private set; }
        public Joueur JoueurBlanc { get; private set; }
        public Joueur JoueurNoir { get; private set; }
        public Joueur JoueurActuel { get; private set; }
        public List<Coup> HistoriqueCoup { get; private set; }
        public bool EstTermine { get; private set; }
        public int PointBlanc { get; private set; }
        public int PointNoir { get; private set; }

        public Partie(Joueur joueurBlanc, Joueur joueurNoir, Gestionnaire gestionnaire)
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
            this.gestionnaire = gestionnaire;
        }
        
        public bool ExecuterCoup(Coup coup)
        {
            Boolean coupValide ;
            if (EstpieceJoueurActuel(coup))
            {
                coupValide = Plateau.EstCoupValide(coup);
                if (!coupValide){
                    AfficherMessageErreur("Le coup joué est un coup invalide");
                }
            } 
            else
            {
                AfficherMessageErreur("La pièce ne correspond pas au joueur actuel.");
                coupValide = false;
                
            }

            if (coupValide)
            {
                Plateau.AppliquerCoup(coup);
                HistoriqueCoup.Add(coup);
                ChangerTour();
                return true;
            }
            
            return false;
        }

        public bool EstpieceJoueurActuel(Coup coup)
        {
            // Le plateau détermine la couleur de la pièce à la position donnée
            bool? pieceBlanche = Plateau.EstPieceBlanche(coup);

            // Si aucune pièce n'existe à la position, le coup est invalide
            if (pieceBlanche == null)
            {
                AfficherMessageErreur("Case de depart vide");
                Thread.Sleep(2000);
                Console.WriteLine("Erreur : Aucun pièce à cette position.");
                return false;
            }

            // Vérification selon le joueur actuel
            if ((JoueurActuel.Equals(JoueurBlanc) && pieceBlanche != true) || (JoueurActuel.Equals(JoueurNoir) && pieceBlanche != false))
            {
                AfficherMessageErreur("Erreur : La pièce ne correspond pas au joueur actuel.");
                Thread.Sleep(2000);
                Console.WriteLine("Erreur : La pièce ne correspond pas au joueur actuel.");
                return false;
            }

            return true; // Coup valide
        }
        
        public void ChangerTour()
        {
            // Alterner JoueurActuel entre JoueurBlanc et JoueurNoir.

            if (JoueurActuel.Equals(JoueurBlanc))
            {
                JoueurActuel = JoueurNoir;
                AfficherMessage("Tour du joueur noir");
            } else
            {
                JoueurActuel = JoueurBlanc;
                AfficherMessage("Tour du joueur blanc");
            }

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
            // Marquer la partie comme terminée
            EstTermine = true;
            Console.WriteLine($"Partie {ID} : marquée comme terminée.");
        }


        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

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
        
        public void AfficherMessageErreur(String message)
        {
            gestionnaire.AfficherMessageErreur(message);
        }
        public void AfficherMessage(String message)
        {
            gestionnaire.AfficherMessage(message);
        }
    }
}
