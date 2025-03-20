using Chess.Modèles.Pièces;
using System;

namespace Chess.Modèles
{
    public class Plateau
    {
        private Piece[,] echequier = new Piece[8, 8];
        public Position EnPassantPosition { get; private set; } = null;

        public void InitialiserPlateau()
        {
            // --- Pièces noires ---
            SetPiece(new Position(0, 0), new Tour(false, new Position(0, 0)));
            SetPiece(new Position(1, 0), new Cavalier(false, new Position(1, 0)));
            SetPiece(new Position(2, 0), new Fou(false, new Position(2, 0)));
            SetPiece(new Position(3, 0), new Reine(false, new Position(3, 0)));
            SetPiece(new Position(4, 0), new Roi(false, new Position(4, 0)));
            SetPiece(new Position(5, 0), new Fou(false, new Position(5, 0)));
            SetPiece(new Position(6, 0), new Cavalier(false, new Position(6, 0)));
            SetPiece(new Position(7, 0), new Tour(false, new Position(7, 0)));

            // Pions noirs 
            for (int x = 0; x < 8; x++)
            {
                SetPiece(new Position(x, 1), new Pion(false, new Position(x, 1)));
            }

            // --- Pièces blanches ---
            SetPiece(new Position(0, 7), new Tour(true, new Position(0, 7)));
            SetPiece(new Position(1, 7), new Cavalier(true, new Position(1, 7)));
            SetPiece(new Position(2, 7), new Fou(true, new Position(2, 7)));
            SetPiece(new Position(3, 7), new Reine(true, new Position(3, 7)));
            SetPiece(new Position(4, 7), new Roi(true, new Position(4, 7)));
            SetPiece(new Position(5, 7), new Fou(true, new Position(5, 7)));
            SetPiece(new Position(6, 7), new Cavalier(true, new Position(6, 7)));
            SetPiece(new Position(7, 7), new Tour(true, new Position(7, 7)));

            // Pions blancs
            for (int x = 0; x < 8; x++)
            {
                SetPiece(new Position(x, 6), new Pion(true, new Position(x, 6)));
            }
        }

        public bool EstCoupValide(Coup coup)
        {
            if (coup == null)
                throw new ArgumentNullException(nameof(coup));

            // Vérifier que les positions de départ et de destination sont valides.
            if (!EstPositionValide(coup.Depart) || !EstPositionValide(coup.Destination))
                return false;

            // Récupérer la pièce à la position de départ.
            Piece pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
            {
                return false;
            }

            // Vérifier que la destination n'est pas occupée par une pièce alliée.
            Piece pieceDestination = GetPiece(coup.Destination);
            if (pieceDestination != null && pieceDestination.IsWhite == pieceDepart.IsWhite)
            {
                return false;
            }

            // Pour les pièces qui ne sautent pas, vérifier que le chemin est libre.
            if (pieceDepart.Type != TypePiece.Cavalier && !EstCheminLibre(coup))
            {
                return false;
            }

            // Déléguer la validation spécifique du mouvement à la pièce concernée.
            if (!pieceDepart.EstMouvementValide(coup))
            {
                return false;
            }

            // TODO: Ajouter d'autres vérifications globales (par exemple, s'assurer que le coup ne met pas le roi en échec).

            return true;
        }

        public bool EstCheminLibre(Coup coup)
        {
            // Calculer les différences en X et Y entre la destination et le départ.
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;

            // Déterminer l'incrément pour X et Y (stepX et stepY)
            // Si dx ou dy est nul, le déplacement se fait uniquement sur l'axe vertical ou horizontal.
            int stepX = (dx == 0) ? 0 : dx / Math.Abs(dx);
            int stepY = (dy == 0) ? 0 : dy / Math.Abs(dy);

            // Commencer à la case immédiatement après la position de départ
            int currentX = coup.Depart.X + stepX;
            int currentY = coup.Depart.Y + stepY;

            // Parcourir toutes les cases entre le départ et la destination, exclus
            while (currentX != coup.Destination.X || currentY != coup.Destination.Y)
            {
                Position posActuelle = new Position(currentX, currentY);
                if (GetPiece(posActuelle) != null)
                {
                    // Une pièce bloque le chemin, le coup est invalide.
                    return false;
                }
                currentX += stepX;
                currentY += stepY;
            }

            // Aucun obstacle détecté sur le chemin.
            return true;
        }

        public void AppliquerCoup(Coup coup)
        {
            throw new NotImplementedException();
        }

        public Piece GetPiece(Position position)
        {
            if (position == null || !EstPositionValide(position))
                throw new ArgumentException("Position invalide.");

            return echequier[position.X, position.Y];
        }

        public void SetPiece(Position position, Piece piece)
        {
            if (position == null || !EstPositionValide(position))
                throw new ArgumentException("Position invalide.");

            echequier[position.X, position.Y] = piece;
        }

        private bool EstPositionValide(Position position)
        {
            return position.X >= 0 && position.X < 8 && position.Y >= 0 && position.Y < 8;
        }

    }
}
