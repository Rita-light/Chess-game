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

            // Déplacement normal : une case dans toutes les directions
            if (dx <= 1 && dy <= 1)
                return true;

            // Tentative de roque : déplacement horizontal de 2 cases
            // -> La validation détaillée est dans EstRoqueValide.
            if (dx == 2 && dy == 0)
                return true;

            return false;
        }

        public override void SetPosition(Position nouvellePosition)
        {
            base.SetPosition(nouvellePosition);
            HasMoved = true;
        }

        public bool EstRoqueValide(Coup coup, Plateau plateau)
        {
            // Le roi ne doit pas avoir bougé
            if (HasMoved)
                return false;

            // Vérifier qu'on se déplace bien de 2 cases sur la même rangée
            int dx = coup.Destination.X - Position.X;
            if (Math.Abs(dx) != 2 || coup.Destination.Y != Position.Y)
                return false;

            // Selon le signe de dx, on détecte un petit ou grand roque
            return (dx > 0) ? EstPetitRoque(plateau) : EstGrandRoque(plateau);
        }

        public bool EstPetitRoque(Plateau plateau)
        {
            // Trouver la tour sur la même ligne, à l'extrême droite (X=7)
            Position tourPos = new Position(7, Position.Y);
            Piece tourPiece = plateau.GetPiece(tourPos);
            if (!PeutParticiperAuRoque(tourPiece))
                return false;

            // Vérifier que les deux cases entre le roi et la tour sont libres
            int y = Position.Y;
            Position case1 = new Position(Position.X + 1, y);
            Position case2 = new Position(Position.X + 2, y);

            if (plateau.GetPiece(case1) != null || plateau.GetPiece(case2) != null)
                return false;

            // TODO: Vérifier que ces cases (et le roi) ne sont pas attaquées.
            return true;
        }

        public bool EstGrandRoque(Plateau plateau)
        {
            // Trouver la tour sur la même ligne, à l'extrême gauche (X=0)
            Position tourPos = new Position(0, Position.Y);
            Piece tourPiece = plateau.GetPiece(tourPos);
            if (!PeutParticiperAuRoque(tourPiece))
                return false;

            // Vérifier que les 3 cases entre le roi et la tour sont libres
            int y = Position.Y;
            Position case1 = new Position(Position.X - 1, y);
            Position case2 = new Position(Position.X - 2, y);
            Position case3 = new Position(Position.X - 3, y);

            if (plateau.GetPiece(case1) != null || plateau.GetPiece(case2) != null || plateau.GetPiece(case3) != null)
                return false;

            // TODO: Vérifier que ces cases (et le roi) ne sont pas attaquées.
            return true;
        }

        // Vérifie si la tour est compatible avec le Roi
        private bool PeutParticiperAuRoque(Piece tourPiece)
        {
            if (tourPiece == null || tourPiece.Type != TypePiece.Tour || tourPiece.IsWhite != IsWhite)
                return false;

            // On suppose que la Tour a aussi un booléen HasMoved, géré de la même façon
            if (tourPiece is Tour tour && tour.HasMoved == false)
                return true;

            return false;
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
