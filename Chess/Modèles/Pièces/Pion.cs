using System;
using System.Collections.Generic;

namespace Chess.Modèles.Pièces
{
    public class Pion : Piece
    {
        public bool HasMoved { get; private set; } = false;

        public Pion(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Pion;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;
            int direction = IsWhite ? -1 : 1;

            if (dx == 0 && dy == direction)
                return true;
            if (dx == 0 && dy == 2 * direction && !HasMoved)
                return true;
            if (EstCoupDeCapture(coup))
                return true;
            return false;
        }

        public bool EstCoupDeCapture(Coup coup)
        {
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;
            int direction = IsWhite ? -1 : 1;
            return Math.Abs(dx) == 1 && dy == direction;
        }

        public override HashSet<Position> ObtenirAttaquesPossibles(Plateau plateau)
        {
            HashSet<Position> attaques = new HashSet<Position>();
            int direction = IsWhite ? -1 : 1;

            int newX1 = Position.X - 1;
            int newY1 = Position.Y + direction;
            int newX2 = Position.X + 1;
            int newY2 = Position.Y + direction;

            if (newX1 >= 0 && newX1 < 8 && newY1 >= 0 && newY1 < 8)
                attaques.Add(new Position(newX1, newY1));
            if (newX2 >= 0 && newX2 < 8 && newY2 >= 0 && newY2 < 8)
                attaques.Add(new Position(newX2, newY2));

            return attaques;
        }

        public override HashSet<Position> ObtenirDestinationsPotentielles(Plateau plateau)
        {
            HashSet<Position> destinations = new HashSet<Position>();
            int direction = IsWhite ? -1 : 1;

            Position posAvant1 = new Position(Position.X, Position.Y + direction);
            if (plateau.EstPositionValide(posAvant1) && plateau.GetPiece(posAvant1) == null)
            {
                destinations.Add(posAvant1);

                if (!HasMoved)
                {
                    Position posAvant2 = new Position(Position.X, Position.Y + 2 * direction);
                    if (plateau.EstPositionValide(posAvant2) && plateau.GetPiece(posAvant2) == null)
                    {
                        destinations.Add(posAvant2);
                    }
                }
            }

            int[] captureDx = { -1, 1 };
            foreach (int dx in captureDx)
            {
                Position posCapture = new Position(Position.X + dx, Position.Y + direction);
                if (plateau.EstPositionValide(posCapture))
                {
                    Piece pieceSurCase = plateau.GetPiece(posCapture);
                    if (pieceSurCase != null && pieceSurCase.IsWhite != IsWhite)
                    {
                        destinations.Add(posCapture);
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
            return IsWhite == false ? "p" : "P";
        }
    }
}
