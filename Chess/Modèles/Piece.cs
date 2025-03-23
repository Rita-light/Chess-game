using System;

namespace Chess.Modèles
{
    public abstract class Piece
    {
        public bool IsWhite { get; private set; }
        public Position Position { get; private set; }
        public TypePiece Type { get; protected set; }

        protected Piece(bool isWhite, Position position)
        {
            if (position == null)
                throw new ArgumentNullException(nameof(position));
            IsWhite = isWhite;
            Position = position;
        }

        public virtual void SetPosition(Position nouvellePosition)
        {
            if (nouvellePosition == null)
                throw new ArgumentNullException(nameof(nouvellePosition));
            if (nouvellePosition.X < 0 || nouvellePosition.X > 7 ||
                nouvellePosition.Y < 0 || nouvellePosition.Y > 7)
                throw new ArgumentOutOfRangeException(nameof(nouvellePosition), "La position doit être entre 0 et 7.");
            Position = nouvellePosition;
        }

        public abstract bool EstMouvementValide(Coup coup);

        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            string couleur = (Type == TypePiece.Reine || Type == TypePiece.Tour)
                     ? (IsWhite ? "Blanche" : "Noire")
                     : (IsWhite ? "Blanc" : "Noir");

            return $"{Type} {couleur} en {Position}";
            // Exemple : Reine Blanche en (2, 4)
        }
    }
}
