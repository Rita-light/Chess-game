namespace Chess.Modèles.Pièces
{
    public class Roi : Piece
    {
        public bool HasMoved { get; private set; } = false;

        public Roi(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Roi;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            return true;
        }

        public override void SetPosition(Position nouvellePosition)
        {
            base.SetPosition(nouvellePosition);
            HasMoved = true;
        }

        // Vérifie si le petit roque est valide pour ce roi
        public bool EstPetitRoqueValide(Coup coup)
        {
            throw new System.NotImplementedException();
        }

        // Vérifie si le grand roque est valide pour ce roi
        public bool EstGrandRoqueValide(Coup coup)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            string couleur = IsWhite ? "Blanc" : "Noir";
            return $"Roi {couleur} en {Position}";
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
