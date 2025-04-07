using System;
using System.Collections.Generic;

namespace Chess.Modèles.Pièces
{
    public class Roi : Piece
    {
        public bool HasMoved { get; set; } = false;

        public Roi(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Roi;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            int dx = Math.Abs(coup.Destination.X - Position.X);
            int dy = Math.Abs(coup.Destination.Y - Position.Y);

            // Mouvement normal du Roi : 1 case
            if (dx <= 1 && dy <= 1)
                return true;

            // Mouv. potentiel de roque : 2 cases sur la même rangée.
            if (dx == 2 && dy == 0)
                return true;

            return false;
        }

        public override HashSet<Position> ObtenirAttaquesPossibles(Plateau plateau)
        {
            HashSet<Position> attaques = new HashSet<Position>();
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue;
                    int newX = Position.X + dx;
                    int newY = Position.Y + dy;
                    if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                    {
                        attaques.Add(new Position(newX, newY));
                    }
                }
            }
            return attaques;
        }

        public override HashSet<Position> ObtenirDestinationsPotentielles(Plateau plateau)
        {
            HashSet<Position> destinations = new HashSet<Position>();
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;

                    int newX = Position.X + dx;
                    int newY = Position.Y + dy;
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
            }
            return destinations;
        }


        public override void SetPosition(Position nouvellePosition)
        {
            base.SetPosition(nouvellePosition);
            HasMoved = true;
        }

        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            return IsWhite == false ? "r" : "R";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Roi autre = (Roi)obj;
            return IsWhite == autre.IsWhite && Position.Equals(autre.Position);
        }

        public override int GetHashCode()
        {
            return (IsWhite, Position).GetHashCode();
        }
    }
}
