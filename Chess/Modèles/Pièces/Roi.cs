using System;

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
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;

            if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1)
            {
                return true;
            }

            if (!HasMoved && dy == 0 && Math.Abs(dx) == 2)
            {
                if (dx == 2)
                {
                    // Petit roque
                    return EstPetitRoque();
                } else if (dx == -2)
                {
                    // Grand roque
                    return EstGrandRoque();
                }
            }

            return false;
        }

        public override void SetPosition(Position nouvellePosition)
        {
            base.SetPosition(nouvellePosition);
            HasMoved = true;
        }

        public bool EstPetitRoque()
        {
            // TODO: Ajouter la vérification du petit roque.
            return true;
        }

        public bool EstGrandRoque()
        {
            // TODO: Ajouter la vérification du grand roque.
            return true;
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
