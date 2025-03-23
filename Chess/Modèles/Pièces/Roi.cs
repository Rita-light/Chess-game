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
            int dx = Math.Abs(coup.Destination.X - Position.X);
            int dy = Math.Abs(coup.Destination.Y - Position.Y);

            // Mouvement normal du Roi : 1 case
            if (dx <= 1 && dy <= 1)
                return true;

            // Mouv. potentiel de roque : 2 cases sur la même rangée.
            if (dx == 2 && dy == 0)
                return true;

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
