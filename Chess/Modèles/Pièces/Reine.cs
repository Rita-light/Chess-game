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
            return true;
        }

        public override string ToString()
        {
            string couleur = IsWhite ? "Blanche" : "Noire";
            return $"Reine {couleur} en {Position}";
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
