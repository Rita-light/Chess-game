using System.Collections.Generic;

namespace Chess.Modèles.Pièces
{
    public class Tour : Piece
    {
        public bool HasMoved { get; set; } = false;

        public Tour(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Tour;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;

            if ((dx == 0 && dy != 0) || (dy == 0 && dx != 0))
            {
                return true;
            }
            return false;
        }

        public override void SetPosition(Position nouvellePosition)
        {
            base.SetPosition(nouvellePosition);
            HasMoved = true;
        }

        public override HashSet<Position> ObtenirAttaquesPossibles(Plateau plateau)
        {
            HashSet<Position> attaques = new HashSet<Position>();
            int[] directionsX = { 1, -1, 0, 0 };
            int[] directionsY = { 0, 0, 1, -1 };

            for (int d = 0; d < 4; d++)
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

        public override HashSet<Position> ObtenirDestinationsPotentielles(Plateau plateau)
        {
            HashSet<Position> destinations = new HashSet<Position>();
            int[] directionsX = { 1, -1, 0, 0 };
            int[] directionsY = { 0, 0, 1, -1 };

            for (int d = 0; d < 4; d++)
            {
                int currentX = Position.X;
                int currentY = Position.Y;
                while (true)
                {
                    currentX += directionsX[d];
                    currentY += directionsY[d];
                    Position posActuelle = new Position(currentX, currentY);

                    if (!plateau.EstPositionValide(posActuelle))
                    {
                        break;
                    }

                    Piece pieceSurCase = plateau.GetPiece(posActuelle);

                    if (pieceSurCase == null)
                    {
                        destinations.Add(posActuelle);
                    } else
                    {
                        if (pieceSurCase.IsWhite != IsWhite)
                        {
                            destinations.Add(posActuelle);
                        }
                        break;
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
            return IsWhite == false ? "t" : "T";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Tour autre = (Tour)obj;
            return IsWhite == autre.IsWhite && Position.Equals(autre.Position);
        }

        public override int GetHashCode()
        {
            return (IsWhite, Position).GetHashCode();
        }
    }
}
