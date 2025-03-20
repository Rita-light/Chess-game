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
            return true;
        }

        public override string ToString()
        {
            string couleur = IsWhite ? "Blanc" : "Noir";
            return $"Cavalier {couleur} en {Position}";
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
