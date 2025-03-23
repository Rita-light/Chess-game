using Chess.Modèles.Pièces;
using System;

namespace Chess.Modèles
{
    public class Plateau
    {
        private Piece[,] echequier = new Piece[8, 8];

        /// <summary>
        /// Case intermédiaire permettant l'en passant (si un pion a avancé de 2 cases).
        /// </summary>
        public Position EnPassantPosition { get; private set; } = null;
        private Arbitre Arbitre;

        public Plateau()
        {
            InitialiserPlateau();
            Arbitre = new Arbitre(this);
        }

        /// <summary>
        /// Place toutes les pièces sur le plateau aux positions de départ.
        /// </summary>
        public void InitialiserPlateau()
        {
            // Pièces noires
            SetPiece(new Position(0, 0), new Tour(false, new Position(0, 0)));
            SetPiece(new Position(1, 0), new Cavalier(false, new Position(1, 0)));
            SetPiece(new Position(2, 0), new Fou(false, new Position(2, 0)));
            SetPiece(new Position(3, 0), new Reine(false, new Position(3, 0)));
            SetPiece(new Position(4, 0), new Roi(false, new Position(4, 0)));
            SetPiece(new Position(5, 0), new Fou(false, new Position(5, 0)));
            SetPiece(new Position(6, 0), new Cavalier(false, new Position(6, 0)));
            SetPiece(new Position(7, 0), new Tour(false, new Position(7, 0)));

            for (int x = 0; x < 8; x++)
                SetPiece(new Position(x, 1), new Pion(false, new Position(x, 1)));

            // Pièces blanches
            SetPiece(new Position(0, 7), new Tour(true, new Position(0, 7)));
            SetPiece(new Position(1, 7), new Cavalier(true, new Position(1, 7)));
            SetPiece(new Position(2, 7), new Fou(true, new Position(2, 7)));
            SetPiece(new Position(3, 7), new Reine(true, new Position(3, 7)));
            SetPiece(new Position(4, 7), new Roi(true, new Position(4, 7)));
            SetPiece(new Position(5, 7), new Fou(true, new Position(5, 7)));
            SetPiece(new Position(6, 7), new Cavalier(true, new Position(6, 7)));
            SetPiece(new Position(7, 7), new Tour(true, new Position(7, 7)));

            for (int x = 0; x < 8; x++)
                SetPiece(new Position(x, 6), new Pion(true, new Position(x, 6)));
        }

        //-------------------------------------------------------------------------
        // Validation principale du coup
        //-------------------------------------------------------------------------

        /// <summary>
        /// Vérifie si un coup est valide selon la logique de déplacement de chaque pièce 
        /// et les règles spéciales (roque, en passant...). Ne gère pas l'échec pour l'instant.
        /// </summary>
        public bool EstCoupValide(Coup coup)
        {
            return Arbitre.EstCoupValide(coup);
        }

        //-------------------------------------------------------------------------
        // Application du coup sur le plateau
        //-------------------------------------------------------------------------

        /// <summary>
        /// Applique réellement le coup validé (déplacement, roque, en passant...).
        /// </summary>
        public void AppliquerCoup(Coup coup)
        {
            if (coup == null)
                throw new ArgumentNullException(nameof(coup));

            Piece pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
                throw new InvalidOperationException("Aucune pièce à déplacer.");

            bool estRoque = EstUnRoque(coup, pieceDepart);

            EffectuerCapture(coup);

            // Déplacement de la pièce
            pieceDepart.SetPosition(coup.Destination);
            SetPiece(coup.Destination, pieceDepart);
            SetPiece(coup.Depart, null);
            
            

            if (estRoque && pieceDepart is Roi)
                AppliquerRoque(coup);
            else if (pieceDepart.Type == TypePiece.Pion)
                ValiderCoupEnPassant(coup, (Pion)pieceDepart);
            else
                ReinitialiserEnPassant();

            // TODO: promotion, etc.
        }

        //-------------------------------------------------------------------------
        // Méthodes internes
        //-------------------------------------------------------------------------

        /// <summary>
        /// Si une pièce se trouve sur la destination, on la retire (capture classique).
        /// </summary>
        private void EffectuerCapture(Coup coup)
        {
            Piece pieceDestination = GetPiece(coup.Destination);
            if (pieceDestination != null)
            {
                SetPiece(coup.Destination, null);
            }
        }

        /// <summary>
        /// Applique le roque en déplaçant la tour associée.
        /// </summary>
        private void AppliquerRoque(Coup coup)
        {
            // Petit roque
            if (coup.Destination.X > coup.Depart.X)
            {
                Position tourPosDepart = new Position(7, coup.Depart.Y);
                Piece tour = GetPiece(tourPosDepart);
                if (tour != null)
                {
                    Position tourPosArrivee = new Position(coup.Destination.X - 1, coup.Destination.Y);
                    tour.SetPosition(tourPosArrivee);
                    SetPiece(tourPosArrivee, tour);
                    SetPiece(tourPosDepart, null);
                }
            }
            // Grand roque
            else
            {
                Position tourPosDepart = new Position(0, coup.Depart.Y);
                Piece tour = GetPiece(tourPosDepart);
                if (tour != null)
                {
                    Position tourPosArrivee = new Position(coup.Destination.X + 1, coup.Destination.Y);
                    tour.SetPosition(tourPosArrivee);
                    SetPiece(tourPosArrivee, tour);
                    SetPiece(tourPosDepart, null);
                }
            }
        }

        /// <summary>
        /// Gère l'en passant pour un pion : 
        /// - fixation de la case intermédiaire si double déplacement
        /// - capture en passant si le pion se déplace diagonalement vers EnPassantPosition
        /// - puis réinitialisation
        /// </summary>
        private void ValiderCoupEnPassant(Coup coup, Pion pion)
        {
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);

            // Double déplacement => enregistrement de la case intermédiaire
            if (dy == 2)
            {
                int intermediateY = (coup.Depart.Y + coup.Destination.Y) / 2;
                EnPassantPosition = new Position(coup.Depart.X, intermediateY);
            } else
            {
                int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
                // Capture en passant (dx==1, dy==1) si la destination == EnPassantPosition
                if (dx == 1 && dy == 1 && coup.Destination.Equals(EnPassantPosition))
                {
                    int captureY = pion.IsWhite ? coup.Destination.Y + 1 : coup.Destination.Y - 1;
                    Position capturedPawnPos = new Position(coup.Destination.X, captureY);
                    SetPiece(capturedPawnPos, null);
                }

                ReinitialiserEnPassant();
            }
        }

        /// <summary>
        /// Réinitialise la case en passant (fin de validité).
        /// </summary>
        private void ReinitialiserEnPassant()
        {
            EnPassantPosition = null;
        }

        //-------------------------------------------------------------------------
        // Méthodes utilitaires
        //-------------------------------------------------------------------------

        private bool EstUnRoque(Coup coup, Piece pieceDepart)
        {
            if (pieceDepart.Type != TypePiece.Roi)
                return false;

            int dx = Math.Abs(coup.Destination.X - coup.Depart.X);
            int dy = Math.Abs(coup.Destination.Y - coup.Depart.Y);
            return (dx == 2 && dy == 0);
        }

        public bool EstCheminLibre(Coup coup)
        {
            int dx = coup.Destination.X - coup.Depart.X;
            int dy = coup.Destination.Y - coup.Depart.Y;
            int stepX = (dx == 0) ? 0 : dx / Math.Abs(dx);
            int stepY = (dy == 0) ? 0 : dy / Math.Abs(dy);

            int currentX = coup.Depart.X + stepX;
            int currentY = coup.Depart.Y + stepY;

            while (currentX != coup.Destination.X || currentY != coup.Destination.Y)
            {
                if (GetPiece(new Position(currentX, currentY)) != null)
                    return false;

                currentX += stepX;
                currentY += stepY;
            }
            return true;
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

        public bool EstPositionValide(Position position)
        {
            return position.X >= 0 && position.X < 8 && position.Y >= 0 && position.Y < 8;
        }
    }
}
