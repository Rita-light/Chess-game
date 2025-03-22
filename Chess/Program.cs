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
            // Tests déjà existants
            TestWhitePetitRoqueValid();
            TestWhiteGrandRoqueValid();
            TestWhitePetitRoqueInvalidObstacle();
            TestWhiteRoqueInvalidKingMoved();
            TestWhiteRoqueInvalidTourMoved();
            TestBlackPetitRoqueValid();
            TestBlackGrandRoqueValid();
            TestBlackPetitRoqueInvalidObstacle();
            TestBlackRoqueInvalidKingMoved();
            TestBlackRoqueInvalidTourMoved();

            // Tests supplémentaires pour des scénarios limites
            TestWhiteRoqueInvalidWrongDestination();
            TestBlackRoqueInvalidWrongDestination();
            TestWhiteRoqueInvalidNotSameRow();
            TestBlackRoqueInvalidNotSameRow();
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

        #region Tests de roque déjà existants

        static void TestWhitePetitRoqueValid()
        {
            Console.WriteLine("Test White Petit Roque Valid");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(7, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(7, 7), whiteTour);

            Coup coup = new Coup(new Position(4, 7), new Position(6, 7));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Coup de petit roque blanc valide ? " + valid);
            if (valid)
            {
                plateau.AppliquerCoup(coup);
                Console.WriteLine("Plateau après petit roque blanc:");
                PrintPlateau(plateau);
            }
            Console.WriteLine();
        }

        static void TestWhiteGrandRoqueValid()
        {
            Console.WriteLine("Test White Grand Roque Valid");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(0, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(0, 7), whiteTour);

            Coup coup = new Coup(new Position(4, 7), new Position(2, 7));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Coup de grand roque blanc valide ? " + valid);
            if (valid)
            {
                plateau.AppliquerCoup(coup);
                Console.WriteLine("Plateau après grand roque blanc:");
                PrintPlateau(plateau);
            }
            Console.WriteLine();
        }

        static void TestWhitePetitRoqueInvalidObstacle()
        {
            Console.WriteLine("Test White Petit Roque Invalid (Obstacle)");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(7, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(7, 7), whiteTour);
            Pion obstacle = new Pion(true, new Position(5, 7));
            plateau.SetPiece(new Position(5, 7), obstacle);

            Coup coup = new Coup(new Position(4, 7), new Position(6, 7));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Petit roque blanc valide avec obstacle ? " + valid);
            Console.WriteLine();
        }

        static void TestWhiteRoqueInvalidKingMoved()
        {
            Console.WriteLine("Test White Roque Invalid (Roi a bougé)");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(7, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(7, 7), whiteTour);
            // Simuler un déplacement antérieur du roi
            whiteKing.SetPosition(new Position(4, 6));
            plateau.SetPiece(new Position(4, 6), whiteKing);
            plateau.SetPiece(new Position(4, 7), null);

            Coup coup = new Coup(new Position(4, 7), new Position(6, 7));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque blanc valide après déplacement du roi ? " + valid);
            Console.WriteLine();
        }

        static void TestWhiteRoqueInvalidTourMoved()
        {
            Console.WriteLine("Test White Roque Invalid (Tour a bougé)");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(7, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(7, 7), whiteTour);
            // Simuler un déplacement antérieur de la tour
            whiteTour.SetPosition(new Position(7, 6));
            plateau.SetPiece(new Position(7, 6), whiteTour);
            plateau.SetPiece(new Position(7, 7), null);

            Coup coup = new Coup(new Position(4, 7), new Position(6, 7));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque blanc valide après déplacement de la tour ? " + valid);
            Console.WriteLine();
        }

        static void TestBlackPetitRoqueValid()
        {
            Console.WriteLine("Test Black Petit Roque Valid");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(7, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(7, 0), blackTour);

            Coup coup = new Coup(new Position(4, 0), new Position(6, 0));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Petit roque noir valide ? " + valid);
            if (valid)
            {
                plateau.AppliquerCoup(coup);
                Console.WriteLine("Plateau après petit roque noir:");
                PrintPlateau(plateau);
            }
            Console.WriteLine();
        }

        static void TestBlackGrandRoqueValid()
        {
            Console.WriteLine("Test Black Grand Roque Valid");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(0, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(0, 0), blackTour);

            Coup coup = new Coup(new Position(4, 0), new Position(2, 0));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Grand roque noir valide ? " + valid);
            if (valid)
            {
                plateau.AppliquerCoup(coup);
                Console.WriteLine("Plateau après grand roque noir:");
                PrintPlateau(plateau);
            }
            Console.WriteLine();
        }

        static void TestBlackPetitRoqueInvalidObstacle()
        {
            Console.WriteLine("Test Black Petit Roque Invalid (Obstacle)");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(7, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(7, 0), blackTour);
            Pion obstacle = new Pion(false, new Position(5, 0));
            plateau.SetPiece(new Position(5, 0), obstacle);

            Coup coup = new Coup(new Position(4, 0), new Position(6, 0));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Petit roque noir valide avec obstacle ? " + valid);
            Console.WriteLine();
        }

        static void TestBlackRoqueInvalidKingMoved()
        {
            Console.WriteLine("Test Black Roque Invalid (Roi a bougé)");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(7, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(7, 0), blackTour);
            // Simuler que le roi a déjà bougé
            blackKing.SetPosition(new Position(4, 1));
            plateau.SetPiece(new Position(4, 1), blackKing);
            plateau.SetPiece(new Position(4, 0), null);

            Coup coup = new Coup(new Position(4, 0), new Position(6, 0));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque noir valide après déplacement du roi ? " + valid);
            Console.WriteLine();
        }

        static void TestBlackRoqueInvalidTourMoved()
        {
            Console.WriteLine("Test Black Roque Invalid (Tour a bougé)");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(7, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(7, 0), blackTour);
            // Simuler que la tour a déjà bougé
            blackTour.SetPosition(new Position(7, 1));
            plateau.SetPiece(new Position(7, 1), blackTour);
            plateau.SetPiece(new Position(7, 0), null);

            Coup coup = new Coup(new Position(4, 0), new Position(6, 0));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque noir valide après déplacement de la tour ? " + valid);
            Console.WriteLine();
        }

        #endregion

        #region Tests supplémentaires

        // Test : Déplacement du roi qui ne correspond pas à un roque parce qu'il s'agit d'un déplacement trop long.
        static void TestWhiteRoqueInvalidWrongDestination()
        {
            Console.WriteLine("Test White Roque Invalid (Mauvaise destination)");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(7, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(7, 7), whiteTour);

            // Essayer de déplacer le roi de (4,7) à (7,7) (3 cases, non autorisé)
            Coup coup = new Coup(new Position(4, 7), new Position(7, 7));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque blanc avec destination incorrecte (3 cases) valide ? " + valid);
            Console.WriteLine();
        }

        static void TestBlackRoqueInvalidWrongDestination()
        {
            Console.WriteLine("Test Black Roque Invalid (Mauvaise destination)");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(7, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(7, 0), blackTour);

            // Essayer de déplacer le roi de (4,0) à (7,0) (3 cases, non autorisé)
            Coup coup = new Coup(new Position(4, 0), new Position(7, 0));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque noir avec destination incorrecte (3 cases) valide ? " + valid);
            Console.WriteLine();
        }

        // Test : Déplacement du roi en roque mais avec une modification de ligne (pas sur la même rangée)
        static void TestWhiteRoqueInvalidNotSameRow()
        {
            Console.WriteLine("Test White Roque Invalid (Différente rangée)");
            Plateau plateau = new Plateau();
            Roi whiteKing = new Roi(true, new Position(4, 7));
            Tour whiteTour = new Tour(true, new Position(7, 7));
            plateau.SetPiece(new Position(4, 7), whiteKing);
            plateau.SetPiece(new Position(7, 7), whiteTour);

            // Essayer de déplacer le roi de (4,7) à (6,6) (même distance horizontale mais changement de rangée)
            Coup coup = new Coup(new Position(4, 7), new Position(6, 6));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque blanc avec déplacement hors rangée valide ? " + valid);
            Console.WriteLine();
        }

        static void TestBlackRoqueInvalidNotSameRow()
        {
            Console.WriteLine("Test Black Roque Invalid (Différente rangée)");
            Plateau plateau = new Plateau();
            Roi blackKing = new Roi(false, new Position(4, 0));
            Tour blackTour = new Tour(false, new Position(7, 0));
            plateau.SetPiece(new Position(4, 0), blackKing);
            plateau.SetPiece(new Position(7, 0), blackTour);

            // Essayer de déplacer le roi de (4,0) à (6,1) (changement de rangée)
            Coup coup = new Coup(new Position(4, 0), new Position(6, 1));
            bool valid = plateau.EstCoupValide(coup);
            Console.WriteLine("Roque noir avec déplacement hors rangée valide ? " + valid);
            Console.WriteLine();
        }

        #endregion
    }
}

