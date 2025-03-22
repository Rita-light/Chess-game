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

            // Déplacement normal : 1 case dans toutes les directions
            if (dx <= 1 && dy <= 1)
                return true;

            // Tentative de roque : déplacement horizontal de 2 cases
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
        // Validation du roque
        //-------------------------------------------------------------------------

        /// <summary>
        /// Valide le roque en s'assurant que le Roi n'a pas bougé, que le déplacement est de 2 cases sur la même rangée,
        /// puis en déléguant à EstPetitRoque ou EstGrandRoque.
        /// </summary>
        public bool EstRoqueValide(Coup coup, Plateau plateau)
        {
            if (HasMoved)
                return false;

            int dx = coup.Destination.X - Position.X;
            if (Math.Abs(dx) != 2 || coup.Destination.Y != Position.Y)
                return false;

            return dx > 0 ? EstPetitRoque(plateau) : EstGrandRoque(plateau);
        }

        /// <summary>
        /// Vérifie les conditions pour le petit roque : la tour à l'extrémité droite doit être présente et immobile,
        /// et les cases entre le Roi et la Tour doivent être libres.
        /// </summary>
        public bool EstPetitRoque(Plateau plateau)
        {
            Position tourPos = new Position(7, Position.Y);
            Piece tourPiece = plateau.GetPiece(tourPos);
            if (!PeutParticiperAuRoque(tourPiece))
                return false;

            Position case1 = new Position(Position.X + 1, Position.Y);
            Position case2 = new Position(Position.X + 2, Position.Y);
            if (plateau.GetPiece(case1) != null || plateau.GetPiece(case2) != null)
                return false;

            // TODO: Vérifier que le Roi et les cases traversées ne sont pas attaquées.
            return true;
        }

        /// <summary>
        /// Vérifie les conditions pour le grand roque : la tour à l'extrémité gauche doit être présente et immobile,
        /// et les cases entre le Roi et la Tour doivent être libres.
        /// </summary>
        public bool EstGrandRoque(Plateau plateau)
        {
            Position tourPos = new Position(0, Position.Y);
            Piece tourPiece = plateau.GetPiece(tourPos);
            if (!PeutParticiperAuRoque(tourPiece))
                return false;

            Position case1 = new Position(Position.X - 1, Position.Y);
            Position case2 = new Position(Position.X - 2, Position.Y);
            Position case3 = new Position(Position.X - 3, Position.Y);
            if (plateau.GetPiece(case1) != null || plateau.GetPiece(case2) != null || plateau.GetPiece(case3) != null)
                return false;

            // TODO: Vérifier que le Roi et les cases traversées ne sont pas attaquées.
            return true;
        }

        //-------------------------------------------------------------------------
        // Méthode utilitaire pour le roque
        //-------------------------------------------------------------------------

        /// <summary>
        /// Vérifie si la pièce fournie (supposée être une tour) peut participer au roque.
        /// </summary>
        private bool PeutParticiperAuRoque(Piece tourPiece)
        {
            if (tourPiece == null || tourPiece.Type != TypePiece.Tour || tourPiece.IsWhite != IsWhite)
                return false;

            if (tourPiece is Tour tour && !tour.HasMoved)
                return true;

            return false;
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
