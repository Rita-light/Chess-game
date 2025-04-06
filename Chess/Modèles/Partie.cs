using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Chess.Modèles
{
    public class Partie
    {
        private static int dernierID = 0;
        private Gestionnaire gestionnaire;

        public Arbitre Arbitre { get; private set; }
        public int ID { get; private set; }
        public Plateau Plateau { get; private set; }
        public Joueur JoueurBlanc { get; private set; }
        public Joueur JoueurNoir { get; private set; }
        public Joueur JoueurActuel { get; private set; }
        public List<Coup> HistoriqueCoup { get; private set; }
        public bool EstTermine { get; set; }
        public int PointBlanc { get; private set; }
        public int PointNoir { get; private set; }
        public int Compteur50Coups { get; private set; } = 0;
        public List<string> HistoriquePlateau { get; private set; } = new List<string>();

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
            Arbitre = new Arbitre(Plateau);
        }

        public bool ExecuterCoup(Coup coup)
        {
            Boolean coupValide ;
            if (EstpieceJoueurActuel(coup))
            {
                coupValide = Plateau.EstCoupValide(coup);
                if (!coupValide)
                {
                    AfficherMessageErreur("Le coup joué est un coup invalide");
                }
            } else
            {
                AfficherMessageErreur("La pièce ne correspond pas au joueur actuel.");
                coupValide = false;
            }

            if (coupValide)
            {
                bool estCapture = Plateau.VerifierCapture(coup);
                Plateau.AppliquerCoup(coup);

                if (estCapture)
                {
                    Compteur50Coups = 0;
                    if (JoueurActuel == JoueurBlanc)
                    {
                        PointBlanc += 1; // Mise à jour des points pour le joueur blanc
                    } else if (JoueurActuel == JoueurNoir)
                    {
                        PointNoir += 1; // Mise à jour des points pour le joueur noir
                    }
                } else
                {
                    Compteur50Coups++;
                }

                HistoriqueCoup.Add(coup);

                // Détection mat/pat sur le prochain joueur
                bool prochainJoueurEstBlanc = (JoueurActuel == JoueurBlanc) ? false : true;

                if (Arbitre.EstEchecEtMat(prochainJoueurEstBlanc))
                {
                    // => Échec et mat
                    AfficherMessageErreur("Échec et mat");
                    EstTermine = true;
                    return true;
                } else if (Arbitre.EstPat(prochainJoueurEstBlanc))
                {
                    // => Pat
                    AfficherMessageErreur("Pat - Partie nulle");
                    EstTermine = true;
                    return true;
                }
                ChangerTour();
                EstNulle();
                HistoriquePlateau.Add(Plateau.ToString());

                return true;
            }

            return false;
        }

        public bool EstpieceJoueurActuel(Coup coup)
        {
            // Le plateau détermine la couleur de la pièce à la position donnée
            bool? pieceBlanche = Plateau.EstPieceBlanche(coup.Depart);

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

        public bool AbandonnerPartie(int joueurID)
        {
            // Vérifier quel joueur abandonne
            if (JoueurBlanc.JoueurID == joueurID)
            {
                // Le joueur blanc abandonne
                PointBlanc = 0;
                PointNoir += 1;
            } else if (JoueurNoir.JoueurID == joueurID)
            {
                // Le joueur noir abandonne
                PointNoir = 0;
                PointBlanc += 1;
            } else
            {
                // L'ID du joueur n'est pas valide
                MessageBox.Show(
                    "L'ID donné ne correspond à aucun joueur de la partie.",
                    "Erreur d'abandon",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            EstTermine = true;
            TerminerPartie();
            return true;
        }

        public void DemanderNulle()
        {
            // Donner un point à chaque joueur
            PointBlanc = 1;
            PointNoir = 1;

            // Marquer la partie comme terminée
            EstTermine = true;

            // Exécuter la logique de fin de partie
            TerminerPartie();
        }

        public bool Regle50Coups()
        {
            if (Compteur50Coups >= 50)
            {
                AfficherMessage("Nulle par règle de 50 coups");
            }
            return Compteur50Coups >= 50;
        }

        public bool NulleParBoucle()
        {
            string etatActuel = Plateau.ToString();

            // Vérifier si l'état actuel du plateau existe déjà dans l'historique
            int repetitionCount = HistoriquePlateau.Count(chaine => chaine.Equals(etatActuel));
            return repetitionCount >= 2;
        }

        public void EstNulle()
        {
            bool estNulle = Regle50Coups() || NulleParBoucle();
            if (NulleParBoucle())
            {
                AfficherMessage("Nulle par répétition d'un même plateau");
            }
            if (estNulle)
            {
                // Donner un point à chaque joueur
                PointBlanc = 1;
                PointNoir = 1;

                // Marquer la partie comme terminée
                EstTermine = true;

                // Exécuter la logique de fin de partie
                TerminerPartie();
            }
        }

        public void TerminerPartie()
        {
            if (!EstTermine)
            {
                Console.WriteLine("La partie n'est pas encore terminée.");
                return;
            }

            // Comparer les points et mettre à jour les scores
            if (PointBlanc > PointNoir)
            {
                // Victoire Blanc, Défaite Noir

                gestionnaire.AjusterScore(JoueurBlanc.JoueurID, 1, 0, 0, PointBlanc);
                gestionnaire.AjusterScore(JoueurNoir.JoueurID, 0, 1, 0, PointNoir);
            } else if (PointBlanc == PointNoir)
            {
                // Partie Nulle
                gestionnaire.AjusterScore(JoueurBlanc.JoueurID, 0, 0, 1, PointBlanc);
                gestionnaire.AjusterScore(JoueurNoir.JoueurID, 0, 0, 1, PointNoir);
            } else
            {
                // Victoire Noir, Défaite Blanc
                gestionnaire.AjusterScore(JoueurBlanc.JoueurID, 0, 1, 0, PointBlanc);
                gestionnaire.AjusterScore(JoueurNoir.JoueurID, 1, 0, 0, PointNoir);
            }

            gestionnaire.AjusterClassement();
            Console.WriteLine("Les scores ont été mis à jour.");
            gestionnaire.GererFinPartie();
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
