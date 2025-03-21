using System;

namespace Chess.Modèles.Pièces
{
    public class Fou : Piece
    {
        public Fou(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Fou;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);
            return (dx == dy && dx != 0);
        }

        public override string ToString()
        {
            string couleur = IsWhite ? "Blanc" : "Noir";
            return $"Fou {couleur} en {Position}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Fou autre = (Fou)obj;
            return IsWhite == autre.IsWhite && Position.Equals(autre.Position);
        }

        public override int GetHashCode()
        {
            return (IsWhite, Position).GetHashCode();
        }
    }
}
