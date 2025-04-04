using Chess.Modèles.Pièces;
using System;
using System.Collections.Generic;

namespace Chess.Modèles
{
    public class Arbitre
    {
        private Plateau Plateau;

        public Arbitre(Plateau plateau)
        {
            Plateau = plateau;
        }

        public bool EstCoupValide(Coup coup)
        {
            if (!ValiderCoupBasique(coup, out Piece pieceDepart, out Piece pieceDestination))
                return false;

            if (!pieceDepart.EstMouvementValide(coup))
                return false;

            if (pieceDepart.Type == TypePiece.Roi)
            {
                int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
                int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);

                // Roque (2 cases horizontales)
                if (dx == 2 && dy == 0)
                {
                    Roi roi = (Roi)pieceDepart;
                    if (!ValiderRoque(coup, roi))
                        return false;
                } else
                {
                    // Sinon on vérifie que le chemin est libre (1 case ou mouvement normal)
                    if (!Plateau.EstCheminLibre(coup))
                        return false;
                }
            }
            // Les autres pièces (hors Cavalier) doivent vérifier que le chemin est libre
            else if (pieceDepart.Type != TypePiece.Cavalier)
            {
                if (!Plateau.EstCheminLibre(coup))
                    return false;
            }

            if (pieceDepart.Type == TypePiece.Pion)
            {
                Pion pion = (Pion)pieceDepart;
                // Si ce n'est pas un mouvement de capture (diagonale),
                // alors la case destination DOIT être vide.
                int dx = coup.Destination.X - coup.Depart.X;
                if (dx == 0 && pieceDestination != null)
                    return false;
            }


            // Vérification spécifique à la capture d'un pion (en passant inclus)
            if (!ValiderCapturePion(coup, pieceDepart, pieceDestination))
                return false;

            if (SimulerCoupEtVerifierEchec(coup, pieceDepart, pieceDestination))
                return false;
            
            return true;
        }

        public void TraiterCoupSpecial(Coup coup, Piece pieceDepart)
        {
            // Gérer le roque
            if (pieceDepart != null && pieceDepart.Type == TypePiece.Roi && EstUnRoque(coup, pieceDepart))
            {
                // Appliquer le roque via Plateau
                Plateau.AppliquerRoque(coup);
                return;
            }

            // Gérer l'en passant pour un pion
            if (pieceDepart != null && pieceDepart.Type == TypePiece.Pion)
            {
                // Valider et appliquer l'en passant
                Plateau.ValiderCoupEnPassant(coup, (Pion)pieceDepart);
                return;
            }

            // Si aucun coup spécial n'est détecté, réinitialiser la case en passant
            Plateau.ReinitialiserEnPassant();
        }

        //-------------------------------------------------------------------------
        // Méthodes internes
        //-------------------------------------------------------------------------

        private bool EstUnRoque(Coup coup, Piece pieceDepart)
        {
            if (pieceDepart.Type != TypePiece.Roi)
                return false;

            int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);
            return (dx == 2 && dy == 0);
        }

        private bool SimulerCoupEtVerifierEchec(Coup coup, Piece pieceDepart, Piece pieceDestination)
        {
            // Sauvegarde de la position initiale
            Position positionInitiale = pieceDepart.Position;

            // Simulation du coup
            Plateau.SetPiece(coup.Depart, null);
            Plateau.SetPiece(coup.Destination, pieceDepart);
            pieceDepart.SetPosition(coup.Destination);

            // Vérifier l'échec pour le roi de la même couleur que la pièce déplacée
            bool enEchec = Plateau.EstEnEchec(pieceDepart.IsWhite);

            // Rollback de la simulation
            Plateau.SetPiece(coup.Depart, pieceDepart);
            Plateau.SetPiece(coup.Destination, pieceDestination);
            pieceDepart.SetPosition(positionInitiale);

            return enEchec;
        }

        private bool ValiderCoupBasique(Coup coup, out Piece pieceDepart, out Piece pieceDestination)
        {
            pieceDepart = null;
            pieceDestination = null;

            if (coup == null)
                return false;

            if (!Plateau.EstPositionValide(coup.Depart) || !Plateau.EstPositionValide(coup.Destination))
                return false;

            pieceDepart = Plateau.GetPiece(coup.Depart);
            if (pieceDepart == null)
                return false;

            pieceDestination = Plateau.GetPiece(coup.Destination);
            // Interdiction de capturer sa propre couleur
            if (pieceDestination != null && pieceDestination.IsWhite == pieceDepart.IsWhite)
                return false;

            return true;
        }

        private bool ValiderCapturePion(Coup coup, Piece pieceDepart, Piece pieceDestination)
        {
            if (pieceDepart.Type == TypePiece.Pion)
            {
                Pion pion = (Pion)pieceDepart;
                // S’il s’agit d’un coup de capture (diagonale) et qu’il n’y a pas de pièce en destination...
                if (pion.EstCoupDeCapture(coup) && pieceDestination == null)
                {
                    // ... on n’accepte que si la destination == EnPassantPosition
                    if (!coup.Destination.Equals(Plateau.EnPassantPosition))
                        return false;
                }
            }
            return true;
        }

        private bool ValiderRoque(Coup coup, Roi roi)
        {
            // Vérifier que le Roi n'a pas bougé
            if (roi.HasMoved)
                return false;

            // Vérifier qu’il se déplace bien de 2 cases
            int dx = coup.Destination.X - roi.Position.X;
            if (Math.Abs(dx) != 2)
                return false;

            return (dx > 0)
                ? EstPetitRoqueValide(coup, roi)
                : EstGrandRoqueValide(coup, roi);
        }

        private bool EstPetitRoqueValide(Coup coup, Roi roi)
        {
            // 1. Vérifier que le roi n'a pas bougé
            if (roi.HasMoved)
                return false;

            // 2. Vérifier que le roi n'est pas déjà en échec
            if (Plateau.EstEnEchec(roi.IsWhite))
                return false;

            // 3. Vérifier la tour située sur le côté droit (position (7, roi.Position.Y))
            Position tourPos = new Position(7, roi.Position.Y);
            Piece tour = Plateau.GetPiece(tourPos);
            if (!PeutParticiperAuRoque(tour, roi.IsWhite))
                return false;

            // 4. Vérifier que les cases intermédiaires sont libres :
            //    Pour un petit roque, ce sont (roi.Position.X + 1, roi.Position.Y) et (roi.Position.X + 2, roi.Position.Y)
            Position posInter1 = new Position(roi.Position.X + 1, roi.Position.Y);
            Position posInter2 = new Position(roi.Position.X + 2, roi.Position.Y);
            if (Plateau.GetPiece(posInter1) != null || Plateau.GetPiece(posInter2) != null)
                return false;

            // 5. Récupérer les cases attaquées par l'adversaire
            HashSet<Position> attaquesAdverses = Plateau.ObtenirAttaques(!roi.IsWhite);

            // 6. Vérifier que le roi ne se trouve pas en échec sur sa position actuelle,
            //    sur la case intermédiaire et sur la case d'arrivée
            if (attaquesAdverses.Contains(roi.Position) ||
                attaquesAdverses.Contains(posInter1) ||
                attaquesAdverses.Contains(posInter2))
            {
                return false;
            }

            // 7. Vérifier que le déplacement du roi correspond bien à un petit roque (2 cases à droite)
            int dx = coup.Destination.X - roi.Position.X;
            if (dx != 2)
                return false;

            return true;
        }

        private bool EstGrandRoqueValide(Coup coup, Roi roi)
        {
            // 1. Vérifier que le roi n'a pas bougé
            if (roi.HasMoved)
                return false;

            // 2. Vérifier que le roi n'est pas déjà en échec
            if (Plateau.EstEnEchec(roi.IsWhite))
                return false;

            // 3. Vérifier la tour située sur le côté gauche (position (0, roi.Position.Y))
            Position tourPos = new Position(0, roi.Position.Y);
            Piece tour = Plateau.GetPiece(tourPos);
            if (!PeutParticiperAuRoque(tour, roi.IsWhite))
                return false;

            // 4. Vérifier que les cases intermédiaires sont libres :
            //    Pour un grand roque, ce sont (roi.Position.X - 1, roi.Position.Y),
            //    (roi.Position.X - 2, roi.Position.Y) et (roi.Position.X - 3, roi.Position.Y)
            Position posInter1 = new Position(roi.Position.X - 1, roi.Position.Y);
            Position posInter2 = new Position(roi.Position.X - 2, roi.Position.Y);
            Position posInter3 = new Position(roi.Position.X - 3, roi.Position.Y);
            if (Plateau.GetPiece(posInter1) != null ||
                Plateau.GetPiece(posInter2) != null ||
                Plateau.GetPiece(posInter3) != null)
                return false;

            // 5. Récupérer les cases attaquées par l'adversaire
            HashSet<Position> attaquesAdverses = Plateau.ObtenirAttaques(!roi.IsWhite);

            // 6. Vérifier que le roi ne se trouve pas en échec sur sa position actuelle,
            //    sur la case intermédiaire et sur la case d'arrivée
            if (attaquesAdverses.Contains(roi.Position) ||
                attaquesAdverses.Contains(posInter1) ||
                attaquesAdverses.Contains(posInter2))
            {
                return false;
            }

            // 7. Vérifier que le déplacement du roi correspond bien à un grand roque (2 cases à gauche)
            int dx = coup.Destination.X - roi.Position.X;
            if (dx != -2)
                return false;

            return true;
        }

        private bool PeutParticiperAuRoque(Piece piece, bool roiBlanc)
        {
            if (piece == null
                || piece.Type != TypePiece.Tour
                || piece.IsWhite != roiBlanc)
            {
                return false;
            }

            if (piece is Tour tour && !tour.HasMoved)
                return true;

            return false;
        }
    }
}
