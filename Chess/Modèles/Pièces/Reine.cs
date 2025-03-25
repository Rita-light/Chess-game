using System;
using System.Collections.Generic;

namespace Chess.Modèles.Pièces
{
    public class Reine : Piece
    {
        public Reine(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Reine;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);
            return ((dx == 0 && dy != 0) || (dy == 0 && dx != 0) || (dx == dy && dx != 0));
        }

        public override HashSet<Position> ObtenirAttaquesPossibles(Plateau plateau)
        {
            HashSet<Position> attaques = new HashSet<Position>();
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int d = 0; d < 8; d++)
            {
                int currentX = Position.X;
                int currentY = Position.Y;
                while (true)
                {
                    currentX += directionsX[d];
                    currentY += directionsY[d];
                    if (currentX < 0 || currentX >= 8 || currentY < 0 || currentY >= 8)
                        break;
                    attaques.Add(new Position(currentX, currentY));
                    if (plateau.GetPiece(new Position(currentX, currentY)) != null)
                        break;
                }
            }
            return attaques;
        }


        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            return IsWhite == false ? "q" : "Q";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Reine autre = (Reine)obj;
            return IsWhite == autre.IsWhite && Position.Equals(autre.Position);
        }

        public override int GetHashCode()
        {
            return (IsWhite, Position).GetHashCode();
        }
    }
}
