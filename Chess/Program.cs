using Chess.Modèles;
using Chess.Modèles.Pièces;
using System;

namespace Chess
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TestWhiteDoubleMoveSetsEnPassant();
            TestBlackEnPassantCapture();
            TestWhiteEnPassantCapture();
            TestEnPassantReset();

        }
        static void PrintPlateau(Plateau plateau)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Position pos = new Position(x, y);
                    Piece p = plateau.GetPiece(pos);
                    Console.Write((p != null ? p.ToString() : "-").PadRight(25));
                }
                Console.WriteLine();
            }
        }

        // Vide le plateau en mettant toutes les cases à null.
        static void ClearPlateau(Plateau plateau)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    plateau.SetPiece(new Position(x, y), null);
                }
            }
        }

        /// <summary>
        /// Teste qu'un pion blanc qui effectue un double déplacement fixe correctement EnPassantPosition.
        /// </summary>
        static void TestWhiteDoubleMoveSetsEnPassant()
        {
            Console.WriteLine("Test White Double Move - EnPassantPosition set");
            Plateau plateau = new Plateau();
            ClearPlateau(plateau);

            // Placer un pion blanc en (4,6)
            Pion whitePawn = new Pion(true, new Position(4, 6));
            plateau.SetPiece(new Position(4, 6), whitePawn);

            // Coup double : de (4,6) à (4,4)
            Coup coup = new Coup(new Position(4, 6), new Position(4, 4));
            if (plateau.EstCoupValide(coup))
            {
                plateau.AppliquerCoup(coup);
                Console.WriteLine("Double move valid.");
                Console.WriteLine("EnPassantPosition attendue : (4,5) => " + plateau.EnPassantPosition);
            } else
                Console.WriteLine("Double move invalid.");

            PrintPlateau(plateau);
            Console.WriteLine();
        }

        /// <summary>
        /// Teste qu'un pion noir peut capturer en passant un pion blanc qui vient de faire un double déplacement.
        /// </summary>
        static void TestBlackEnPassantCapture()
        {
            Console.WriteLine("Test Black En Passant Capture");
            Plateau plateau = new Plateau();
            ClearPlateau(plateau);

            // Placer un pion blanc en (4,6) et le faire avancer de 2 cases -> (4,4)
            Pion whitePawn = new Pion(true, new Position(4, 6));
            plateau.SetPiece(new Position(4, 6), whitePawn);
            Coup whiteDouble = new Coup(new Position(4, 6), new Position(4, 4));
            if (plateau.EstCoupValide(whiteDouble))
                plateau.AppliquerCoup(whiteDouble);
            else
            {
                Console.WriteLine("White double move invalid");
                return;
            }
            // EnPassantPosition devrait être (4,5)
            Console.WriteLine("EnPassantPosition après double move: " + plateau.EnPassantPosition);

            // Placer un pion noir à (3,4) pour capturer en passant en se déplaçant vers (4,5)
            Pion blackPawn = new Pion(false, new Position(3, 4));
            plateau.SetPiece(new Position(3, 4), blackPawn);

            // Coup d'en passant : pion noir de (3,4) -> (4,5)
            Coup blackEnPassant = new Coup(new Position(3, 4), new Position(4, 5));
            if (plateau.EstCoupValide(blackEnPassant))
            {
                plateau.AppliquerCoup(blackEnPassant);
                Console.WriteLine("En passant capture valid.");
            } else
                Console.WriteLine("En passant capture invalid.");

            // Vérifier que le pion blanc capturé a bien été retiré de (4,4)
            Piece captured = plateau.GetPiece(new Position(4, 4));
            Console.WriteLine("Pion blanc capturé ? " + (captured == null ? "Yes" : "No"));
            PrintPlateau(plateau);
            Console.WriteLine();
        }

        /// <summary>
        /// Teste qu'un pion blanc peut capturer en passant un pion noir qui vient de faire un double déplacement.
        /// </summary>
        static void TestWhiteEnPassantCapture()
        {
            Console.WriteLine("Test White En Passant Capture");
            Plateau plateau = new Plateau();
            ClearPlateau(plateau);

            // Placer un pion noir en (3,1) et le faire avancer de 2 cases -> (3,3)
            Pion blackPawn = new Pion(false, new Position(3, 1));
            plateau.SetPiece(new Position(3, 1), blackPawn);
            Coup blackDouble = new Coup(new Position(3, 1), new Position(3, 3));
            if (plateau.EstCoupValide(blackDouble))
                plateau.AppliquerCoup(blackDouble);
            else
            {
                Console.WriteLine("Black double move invalid");
                return;
            }
            // EnPassantPosition devrait être (3,2)
            Console.WriteLine("EnPassantPosition après double move: " + plateau.EnPassantPosition);

            // Placer un pion blanc à (4,3) pour qu'il capture en passant en se déplaçant vers (3,2)
            Pion whitePawn = new Pion(true, new Position(4, 3));
            plateau.SetPiece(new Position(4, 3), whitePawn);

            // Coup d'en passant : pion blanc de (4,3) -> (3,2)
            Coup whiteEnPassant = new Coup(new Position(4, 3), new Position(3, 2));
            if (plateau.EstCoupValide(whiteEnPassant))
            {
                plateau.AppliquerCoup(whiteEnPassant);
                Console.WriteLine("En passant capture valid.");
            } else
                Console.WriteLine("En passant capture invalid.");

            // Vérifier que le pion noir capturé a bien été retiré de (3,3)
            Piece captured = plateau.GetPiece(new Position(3, 3));
            Console.WriteLine("Pion noir capturé ? " + (captured == null ? "Yes" : "No"));
            PrintPlateau(plateau);
            Console.WriteLine();
        }

        /// <summary>
        /// Teste que la EnPassantPosition est réinitialisée après un coup qui n'est pas un double déplacement.
        /// </summary>
        static void TestEnPassantReset()
        {
            Console.WriteLine("Test EnPassant Reset");
            Plateau plateau = new Plateau();
            ClearPlateau(plateau);

            // Placer un pion blanc et faire un double déplacement pour fixer EnPassantPosition.
            Pion whitePawn = new Pion(true, new Position(4, 6));
            plateau.SetPiece(new Position(4, 6), whitePawn);
            Coup whiteDouble = new Coup(new Position(4, 6), new Position(4, 4));
            if (plateau.EstCoupValide(whiteDouble))
                plateau.AppliquerCoup(whiteDouble);
            Console.WriteLine("EnPassantPosition après double move: " + plateau.EnPassantPosition);

            // Placer un autre pion blanc pour un coup normal qui réinitialisera EnPassantPosition.
            Pion anotherWhitePawn = new Pion(true, new Position(3, 6));
            plateau.SetPiece(new Position(3, 6), anotherWhitePawn);
            Coup simpleMove = new Coup(new Position(3, 6), new Position(3, 5));
            if (plateau.EstCoupValide(simpleMove))
                plateau.AppliquerCoup(simpleMove);

            Console.WriteLine("EnPassantPosition après coup normal: " + plateau.EnPassantPosition);
            PrintPlateau(plateau);
            Console.WriteLine();
        }
    }
}

