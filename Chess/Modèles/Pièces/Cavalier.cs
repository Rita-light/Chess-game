using System;
using System.Collections.Generic;

namespace Chess.Modèles.Pièces
{
    public class Cavalier : Piece
    {
        public Cavalier(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Cavalier;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);
            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }

        public override HashSet<Position> ObtenirAttaquesPossibles(Plateau plateau)
        {
            HashSet<Position> attaques = new HashSet<Position>();
            int[,] offsets = new int[,]
            {
                { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 },
                { -1, -2 }, { -2, -1 }, { -2, 1 }, { -1, 2 }
            };

            for (int i = 0; i < offsets.GetLength(0); i++)
            {
                int newX = Position.X + offsets[i, 0];
                int newY = Position.Y + offsets[i, 1];
                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    attaques.Add(new Position(newX, newY));
                }
            }

            return attaques;
        }

        public override HashSet<Position> ObtenirDestinationsPotentielles(Plateau plateau)
        {
            HashSet<Position> destinations = new HashSet<Position>();
            int[,] offsets = new int[,]
            {
                { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 },
                { -1, -2 }, { -2, -1 }, { -2, 1 }, { -1, 2 }
            };

            for (int i = 0; i < offsets.GetLength(0); i++)
            {
                int newX = Position.X + offsets[i, 0];
                int newY = Position.Y + offsets[i, 1];
                Position posDest = new Position(newX, newY);

                if (plateau.EstPositionValide(posDest))
                {
                    Piece pieceSurCase = plateau.GetPiece(posDest);
                    if (pieceSurCase == null || pieceSurCase.IsWhite != IsWhite)
                    {
                        destinations.Add(posDest);
                    }
                }
            }
            return destinations;
        }

        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            return IsWhite == false ? "c" : "C";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Cavalier autre = (Cavalier)obj;
            return IsWhite == autre.IsWhite && Position.Equals(autre.Position);
        }

        public override int GetHashCode()
        {
            return (IsWhite, Position).GetHashCode();
        }
    }
}
