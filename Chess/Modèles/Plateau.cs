using Chess.Modèles.Pièces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        
        public override string ToString()
        {
            string plateauChaine = "";
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    plateauChaine += echequier[r, c] != null ? echequier[r, c].ToString() : "-";
            return plateauChaine;
        }

        //-------------------------------------------------------------------------
        // Validation principale du coup
        //-------------------------------------------------------------------------

        /// <summary>
        /// Vérifie si un coup est valide selon la logique de déplacement de chaque pièce 
        /// et les règles spéciales (roque, en passant...).
        /// </summary>
        public bool EstCoupValide(Coup coup)
        {
            return Arbitre.EstCoupValide(coup);
        }

        /// <summary>
        /// Verifie la couleur de la pièce à bouger
        /// </summary>
        /// <param name="coup"></param>
        /// <returns></returns>
        public bool? EstPieceBlanche(Position position)
        {
            Piece piece = GetPiece(position);
            if (piece == null)
            {
                return null;
            }
            return piece.IsWhite;
        }

        /// <summary>
        /// verifie si il y a eure une capture
        /// </summary>
        /// <param name="coup"></param>
        /// <returns></returns>
        public bool VerifierCapture(Coup coup)
        {
            bool? couleurPieceDepart = EstPieceBlanche(coup.Depart);
            bool? couleurPieceDestination = EstPieceBlanche(coup.Destination);

            // Si l'une des pièces est null, pas de capture possible
            if (couleurPieceDepart == null || couleurPieceDestination == null)
            {
                return false;
            }

            // Vérifier si les pièces sont de couleurs différentes
            return couleurPieceDepart != couleurPieceDestination;
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

            EffectuerCapture(coup);
            DeplacerPiece(coup);
            Arbitre.TraiterCoupSpecial(coup, pieceDepart);
            
            // Vérifier si le pion est promu
            if (pieceDepart.Type == TypePiece.Pion )
            {
                if (EstEnPromotion(pieceDepart, coup.Destination))
                {
                    PromouvoirPion(pieceDepart, coup.Destination);
                }
            }
        }
        

        private void DeplacerPiece(Coup coup)
        {
            Piece pieceDepart = GetPiece(coup.Depart);
            if (pieceDepart == null)
                throw new InvalidOperationException($"Aucune pièce à déplacer depuis {coup.Depart}.");

            // Mise à jour de la position de la pièce
            pieceDepart.SetPosition(coup.Destination);

            // Mise à jour de l'échiquier
            SetPiece(coup.Destination, pieceDepart);
            SetPiece(coup.Depart, null);
        }
        
        
        //-------------------------------------------------------------------------
        // Promotion pièce
        //-------------------------------------------------------------------------
        /// <summary>
        /// Vétifie si le pion a ateint une position permettant la promotion
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool EstEnPromotion(Piece piece, Position position)
        {
            if (piece is Pion)
            {
                if ((piece.IsWhite && position.Y == 0) || (!piece.IsWhite && position.Y == 7))
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// - Affiche la boite de dialogue pour choisir le type de piece
        /// - Promouvoit le pion en type de pièce choisi
        /// </summary>
        /// <param name="pion"></param>
        /// <param name="position"></param>
        private void PromouvoirPion(Piece pion, Position position)
        {
            char choix = 'D'; // Par défaut

            var form = new PromotionForm(); // Formulaire qui implémente l'interface
            form.ShowDialog();

            choix = form.Choix; // Récupère le choix du joueur

            Piece piecePromue;

            // En fonction du choix et de la couleur du pion
            if (pion.IsWhite) // Si le pion est blanc
            {
                switch (choix)
                {
                    case 'T': piecePromue = new Tour(true, position); break;
                    case 'F': piecePromue = new Fou(true, position); break;
                    case 'C': piecePromue = new Cavalier(true, position); break;
                    default: piecePromue = new Reine(true, position); break;
                }
            }
            else // Si le pion est noir
            {
                switch (choix)
                {
                    case 'T': piecePromue = new Tour(false, position); break;
                    case 'F': piecePromue = new Fou(false, position); break;
                    case 'C': piecePromue = new Cavalier(false, position); break;
                    default: piecePromue = new Reine(false, position); break;
                }
            }

            // Remplacer le pion par la pièce promue sur l'échiquier
            echequier[position.X, position.Y] = piecePromue;
        }

        
        //-------------------------------------------------------------------------
        // Détection de l'échec
        //-------------------------------------------------------------------------

        public HashSet<Position> ObtenirAttaques(bool attaquesBlanches)
        {
            HashSet<Position> casesAttaquees = new HashSet<Position>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Position pos = new Position(x, y);
                    Piece piece = GetPiece(pos);
                    if (piece != null && piece.IsWhite == attaquesBlanches)
                    {
                        // Récupérer les cases attaquées par cette pièce
                        HashSet<Position> attaques = piece.ObtenirAttaquesPossibles(this);
                        foreach (var posAttaque in attaques)
                        {
                            casesAttaquees.Add(posAttaque);
                        }
                    }
                }
            }
            return casesAttaquees;
        }

        public bool EstEnEchec(bool estBlanc)
        {
            // Trouver la position du roi de la couleur indiquée
            Position positionRoi = null;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Position pos = new Position(x, y);
                    Piece piece = GetPiece(pos);
                    if (piece != null && piece.Type == TypePiece.Roi && piece.IsWhite == estBlanc)
                    {
                        positionRoi = pos;
                        break;
                    }
                }
                if (positionRoi != null)
                    break;
            }

            if (positionRoi == null)
                throw new Exception("Roi non trouvé !");

            // Obtenir les cases attaquées par l'adversaire
            HashSet<Position> casesAttaqueesAdverses = ObtenirAttaques(!estBlanc);

            // Le roi est en échec si sa position se trouve parmi les cases attaquées
            return casesAttaqueesAdverses.Contains(positionRoi);
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
        public void AppliquerRoque(Coup coup)
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
        public void ValiderCoupEnPassant(Coup coup, Pion pion)
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

        public void ReinitialiserEnPassant()
        {
            EnPassantPosition = null;
        }

        //-------------------------------------------------------------------------
        // Méthodes utilitaires
        //-------------------------------------------------------------------------

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
