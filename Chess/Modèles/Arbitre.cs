using Chess.Modèles.Pièces;
using System;

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

            // Vérification élémentaire du mouvement pour la pièce
            if (!pieceDepart.EstMouvementValide(coup))
                return false;

            // Gestion spéciale du Roi (roque)
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

            // Vérification spécifique à la capture d'un pion (en passant inclus)
            if (!ValiderCapturePion(coup, pieceDepart, pieceDestination))
                return false;

            return true;
        }

        //-------------------------------------------------------------------------
        // Méthodes internes
        //-------------------------------------------------------------------------

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
            Position tourPos = new Position(7, roi.Position.Y);
            Piece tourPiece = Plateau.GetPiece(tourPos);

            if (!PeutParticiperAuRoque(tourPiece, roi.IsWhite))
                return false;

            Position case1 = new Position(roi.Position.X + 1, roi.Position.Y);
            Position case2 = new Position(roi.Position.X + 2, roi.Position.Y);
            if (Plateau.GetPiece(case1) != null || Plateau.GetPiece(case2) != null)
                return false;

            return true;
        }

        private bool EstGrandRoqueValide(Coup coup, Roi roi)
        {
            Position tourPos = new Position(0, roi.Position.Y);
            Piece tourPiece = Plateau.GetPiece(tourPos);

            if (!PeutParticiperAuRoque(tourPiece, roi.IsWhite))
                return false;

            Position case1 = new Position(roi.Position.X - 1, roi.Position.Y);
            Position case2 = new Position(roi.Position.X - 2, roi.Position.Y);
            Position case3 = new Position(roi.Position.X - 3, roi.Position.Y);

            if (Plateau.GetPiece(case1) != null
                || Plateau.GetPiece(case2) != null
                || Plateau.GetPiece(case3) != null)
            {
                return false;
            }

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
