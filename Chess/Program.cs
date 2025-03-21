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
            TestPionDiagonalSansCapture();
            Console.WriteLine();
            TestPionDiagonalAvecCapture();
        }
        /// <summary>
        /// Affiche le plateau en parcourant chaque case.
        /// </summary>
        /// <param name="plateau">L'instance du plateau</param>
        static void PrintPlateau(Plateau plateau)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Position pos = new Position(x, y);
                    Piece piece = plateau.GetPiece(pos);
                    string affichage = (piece != null) ? piece.ToString() : " - ";
                    Console.Write($"{affichage,-30}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Teste un déplacement diagonal pour un pion sans capture (la case destination est vide).
        /// Ce coup devrait être refusé.
        /// </summary>
        static void TestPionDiagonalSansCapture()
        {
            Console.WriteLine("Test : Déplacement diagonal d'un pion sans capture");
            Plateau plateau = new Plateau();

            // Placer un pion blanc en (4,6)
            Pion pionBlanc = new Pion(true, new Position(4, 6));
            plateau.SetPiece(new Position(4, 6), pionBlanc);

            // Affichage initial
            Console.WriteLine("Plateau initial :");
            PrintPlateau(plateau);

            // Tenter un déplacement diagonal : de (4,6) à (3,5)
            Coup coup = new Coup(new Position(4, 6), new Position(3, 5));
            bool coupValide = plateau.EstCoupValide(coup);
            Console.WriteLine($"\nPion diagonal sans capture de (4,6) à (3,5) valide ? {coupValide}");
            // Attendu : false, car la case destination est vide (aucune pièce adverse)
        }

        /// <summary>
        /// Teste un déplacement diagonal pour un pion avec capture (la case destination contient une pièce ennemie).
        /// Ce coup devrait être accepté.
        /// </summary>
        static void TestPionDiagonalAvecCapture()
        {
            Console.WriteLine("Test : Déplacement diagonal d'un pion avec capture");
            Plateau plateau = new Plateau();

            // Placer un pion blanc en (4,6)
            Pion pionBlanc = new Pion(true, new Position(4, 6));
            plateau.SetPiece(new Position(4, 6), pionBlanc);

            // Placer une pièce ennemie (par exemple, un pion noir) en (3,5)
            Pion pionNoir = new Pion(false, new Position(3, 5));
            plateau.SetPiece(new Position(3, 5), pionNoir);

            // Affichage initial
            Console.WriteLine("Plateau initial :");
            PrintPlateau(plateau);

            // Tenter le déplacement diagonal du pion blanc vers (3,5)
            Coup coup = new Coup(new Position(4, 6), new Position(3, 5));
            bool coupValide = plateau.EstCoupValide(coup);
            Console.WriteLine($"\nPion diagonal avec capture de (4,6) à (3,5) valide ? {coupValide}");
            // Attendu : true, car la case destination contient un pion adverse
        }
    }
}

