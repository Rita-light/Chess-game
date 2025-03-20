using System;

namespace Chess.Modèles
{
    public class Plateau
    {
        private Piece[,] echequier = new Piece[8, 8];
        public Position EnPassantPosition { get; private set; } = null;

        public void InitialiserPlateau()
        {
            throw new NotImplementedException();
        }

        public bool EstCoupValide(Coup coup)
        {
            throw new NotImplementedException();
        }

        public bool EstCheminLibre(Coup coup)
        {
            throw new NotImplementedException();
        }

        public void AppliquerCoup(Coup coup)
        {
            throw new NotImplementedException();
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
