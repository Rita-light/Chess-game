using System;

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
            return this.IsWhite == false ? "p" : "P";
        }
    }
}
