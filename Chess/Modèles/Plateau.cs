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
            if (coup == null)
                throw new ArgumentNullException(nameof(coup));

            if (!EstPositionValide(coup.Depart) || !EstPositionValide(coup.Destination))
                return false;

            Piece pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
                return false;

            Piece pieceDestination = GetPiece(coup.Destination);
            if (pieceDestination != null && pieceDestination.IsWhite == pieceDepart.IsWhite)
                return false;

            if (pieceDepart.Type != TypePiece.Cavalier && !EstCheminLibre(coup))
                return false;

            if (pieceDepart.Type == TypePiece.Pion)
            {
                Pion pion = (Pion)pieceDepart;
                if (pion.EstCoupDeCapture(coup) && GetPiece(coup.Destination) == null)
                    return false;
            }

            if (!pieceDepart.EstMouvementValide(coup))
                return false;

            // TODO: Vérifications supplémentaires (par exemple, pour l'échec).

            return true;
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

        public void AppliquerCoup(Coup coup)
        {
            if (coup == null)
                throw new ArgumentNullException(nameof(coup));

            Piece pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
                throw new InvalidOperationException("Aucune pièce à déplacer.");

            Piece pieceDestination = GetPiece(coup.Destination);
            if (pieceDestination != null)
                SetPiece(coup.Destination, null);

            pieceDepart.SetPosition(coup.Destination);
            SetPiece(coup.Destination, pieceDepart);
            SetPiece(coup.Depart, null);

            // TODO: Gérer la promotion, l'en passant et le roque.
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
