namespace Chess.Modèles.Pièces
{
    public class Pion : Piece
    {
        public bool HasMoved { get; private set; } = false;

        public Pion(bool isWhite, Position position) : base(isWhite, position)
        {
            Type = TypePiece.Pion;
        }

        public override bool EstMouvementValide(Coup coup)
        {
            return true;
        }

        public bool EstEnPassantValide(Coup coup, Position enPassantPosition)
        {
            throw new System.NotImplementedException();
        }

        public override void SetPosition(Position nouvellePosition)
        {
            base.SetPosition(nouvellePosition);
            HasMoved = true;
        }

        public override string ToString()
        {
            // Exemple d'affichage : "Pion Blanc en (3, 5)"
            string couleur = IsWhite ? "Blanc" : "Noir";
            return $"Pion {couleur} en {Position}";
        }
    }
}
