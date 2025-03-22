using Chess.Modèles;
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
            testSerealization();

        }
        static void testSerealization()
        {
            // Instanciation du gestionnaire
            Gestionnaire gestionnaire = new Gestionnaire();

            // Ajouter des joueurs à la liste
            gestionnaire.listJoueurs.Add(new Joueur("VAlice"));
            gestionnaire.listJoueurs.Add(new Joueur("BiBob"));

            // Ajouter des scores à la liste
            gestionnaire.listeScores.Add(new Score(new Joueur("Alice"), 1800));
            gestionnaire.listeScores.Add(new Score(new Joueur("Bob"), 1700));

            // Sauvegarder les données
            gestionnaire.SauvegarderTout();



            // Afficher les joueurs
            Console.WriteLine("Liste des joueurs :");
            foreach (var joueur in gestionnaire.listJoueurs)
            {
                Console.WriteLine(joueur.ToString());
            }

            // Afficher les scores
            Console.WriteLine("\nListe des scores :");
            foreach (var score in gestionnaire.listeScores)
            {
                Console.WriteLine(score.ToString());
            }
        }
    }
}
