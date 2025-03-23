namespace Chess.Modèles.Pièces
{
    public class Tour : Piece
    {
        public bool HasMoved { get; private set; } = false;

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

        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            string couleur = IsWhite ? "Blanche" : "Noire";
            return $"Tour {couleur} en {Position}";
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
