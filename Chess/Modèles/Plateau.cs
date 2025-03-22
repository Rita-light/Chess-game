using Chess.Modèles.Pièces;
using System;

namespace Chess.Modèles
{
    public class Plateau
    {
        private Piece[,] echequier = new Piece[8, 8];
        public Position EnPassantPosition { get; private set; } = null;
        
        public Plateau()
        {
            InitialiserPlateau();
        }
        
        public void InitialiserPlateau()
        {
            // Pièces noires
            SetPiece(new Position(0, 0), new Tour(false, new Position(0, 0)));
            SetPiece(new Position(1, 0), new Cavalier(false, new Position(1, 0)));
            SetPiece(new Position(2, 0), new Fou(false, new Position(2, 0)));
            SetPiece(new Position(3, 0), new Reine(false, new Position(3, 0)));
            SetPiece(new Position(4, 0), new Roi(false, new Position(4, 0)));
            SetPiece(new Position(5, 0), new Fou(false, new Position(5, 0)));
            SetPiece(new Position(6, 0), new Cavalier(false, new Position(6, 0)));
            SetPiece(new Position(7, 0), new Tour(false, new Position(7, 0)));

            for (int x = 0; x < 8; x++)
                SetPiece(new Position(x, 1), new Pion(false, new Position(x, 1)));

            // Pièces blanches
            SetPiece(new Position(0, 7), new Tour(true, new Position(0, 7)));
            SetPiece(new Position(1, 7), new Cavalier(true, new Position(1, 7)));
            SetPiece(new Position(2, 7), new Fou(true, new Position(2, 7)));
            SetPiece(new Position(3, 7), new Reine(true, new Position(3, 7)));
            SetPiece(new Position(4, 7), new Roi(true, new Position(4, 7)));
            SetPiece(new Position(5, 7), new Fou(true, new Position(5, 7)));
            SetPiece(new Position(6, 7), new Cavalier(true, new Position(6, 7)));
            SetPiece(new Position(7, 7), new Tour(true, new Position(7, 7)));

            for (int x = 0; x < 8; x++)
                SetPiece(new Position(x, 6), new Pion(true, new Position(x, 6)));
        }

        public bool EstCoupValide(Coup coup)
        {
            if (!ValiderCoupBasique(coup, out Piece pieceDepart, out Piece pieceDestination))
                return false;

            // Vérifier que le pattern du coup correspond bien au déplacement de la pièce.
            if (!pieceDepart.EstMouvementValide(coup))
                return false;

            if (!ValiderCheminOuRoque(coup, pieceDepart))
                return false;

            if (!ValiderCapturePion(coup, pieceDepart, pieceDestination))
                return false;

            // TODO: ajouter d'autres vérifications globales (échec, etc.)
            return true;
        }

        public void AppliquerCoup(Coup coup)
        {
            if (coup == null)
                throw new ArgumentNullException(nameof(coup));

            Piece pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
                throw new InvalidOperationException("Aucune pièce à déplacer.");

            bool estRoque = EstUnRoque(coup, pieceDepart);

            EffectuerCapture(coup);

            // Déplacer la pièce de départ
            pieceDepart.SetPosition(coup.Destination);
            SetPiece(coup.Destination, pieceDepart);
            SetPiece(coup.Depart, null);

            if (estRoque && pieceDepart is Roi)
                AppliquerRoque(coup);

            // TODO: promotion, en passant, etc.
        }

        private bool ValiderCoupBasique(Coup coup, out Piece pieceDepart, out Piece pieceDestination)
        {
            pieceDepart = null;
            pieceDestination = null;

            if (coup == null)
                return false;

            if (!EstPositionValide(coup.Depart) || !EstPositionValide(coup.Destination))
                return false;

            pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
                return false;

            pieceDestination = GetPiece(coup.Destination);
            if (pieceDestination != null && pieceDestination.IsWhite == pieceDepart.IsWhite)
                return false;

            return true;
        }

        private bool ValiderCheminOuRoque(Coup coup, Piece pieceDepart)
        {
            if (pieceDepart.Type == TypePiece.Roi)
            {
                int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
                int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);

                // Roque : 2 cases horizontalement
                if (dx == 2 && dy == 0)
                {
                    Roi roi = (Roi)pieceDepart;
                    if (!roi.EstRoqueValide(coup, this))
                        return false;
                } else
                {
                    // Sinon, chemin libre si ce n'est pas un Cavalier.
                    if (!EstCheminLibre(coup))
                        return false;
                }
            } else if (pieceDepart.Type != TypePiece.Cavalier)
            {
                // Tour, Fou, Reine, Pion => besoin d'un chemin libre
                if (!EstCheminLibre(coup))
                    return false;
            }
            return true;
        }

        private bool ValiderCapturePion(Coup coup, Piece pieceDepart, Piece pieceDestination)
        {
            if (pieceDepart.Type == TypePiece.Pion)
            {
                Pion pion = (Pion)pieceDepart;
                if (pion.EstCoupDeCapture(coup) && pieceDestination == null)
                    return false;
            }
            return true;
        }

        private bool EstUnRoque(Coup coup, Piece pieceDepart)
        {
            if (pieceDepart.Type != TypePiece.Roi)
                return false;

            int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);
            return (dx == 2 && dy == 0);
        }

        private void EffectuerCapture(Coup coup)
        {
            Piece pieceDestination = GetPiece(coup.Destination);
            if (pieceDestination != null)
            {
                // Retirer la pièce capturée
                SetPiece(coup.Destination, null);
            }
        }

        private void AppliquerRoque(Coup coup)
        {
            // Petit roque => tour en (7, Y)
            if (coup.Destination.X > coup.Depart.X)
            {
                Position tourPosDepart = new Position(7, coup.Depart.Y);
                Piece tour = GetPiece(tourPosDepart);
                if (tour != null)
                {
                    Position tourPosArrivee = new Position(coup.Destination.X - 1, coup.Destination.Y);
                    tour.SetPosition(tourPosArrivee);
                    SetPiece(tourPosArrivee, tour);
                    SetPiece(tourPosDepart, null);
                }
            }
            // Grand roque => tour en (0, Y)
            else
            {
                Position tourPosDepart = new Position(0, coup.Depart.Y);
                Piece tour = GetPiece(tourPosDepart);
                if (tour != null)
                {
                    Position tourPosArrivee = new Position(coup.Destination.X + 1, coup.Destination.Y);
                    tour.SetPosition(tourPosArrivee);
                    SetPiece(tourPosArrivee, tour);
                    SetPiece(tourPosDepart, null);
                }
            }
        }

        public bool EstCheminLibre(Coup coup)
        {
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;
            int stepX = (dx == 0) ? 0 : dx / Math.Abs(dx);
            int stepY = (dy == 0) ? 0 : dy / Math.Abs(dy);
            int currentX = coup.Depart.X + stepX;
            int currentY = coup.Depart.Y + stepY;

            while (currentX != coup.Destination.X || currentY != coup.Destination.Y)
            {
                if (GetPiece(new Position(currentX, currentY)) != null)
                    return false;
                currentX += stepX;
                currentY += stepY;
            }
            return true;
        }

        public Piece GetPiece(Position position)
        {
            if (position == null || !EstPositionValide(position))
                throw new ArgumentException("Position invalide.");
            return echequier[position.X, position.Y];
        }

        public void SetPiece(Position position, Piece piece)
        {
            if (position == null || !EstPositionValide(position))
                throw new ArgumentException("Position invalide.");
            echequier[position.X, position.Y] = piece;
        }

        private bool EstPositionValide(Position position)
        {
            return position.X >= 0 && position.X < 8 && position.Y >= 0 && position.Y < 8;
        }
    }
}
