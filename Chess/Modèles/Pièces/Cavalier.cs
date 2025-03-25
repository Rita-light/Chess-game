using System;

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

        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            return this.IsWhite == false ? "c" : "C";
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
