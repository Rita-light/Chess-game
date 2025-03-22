using Chess.Modèles;
using Chess.Modèles.Pièces;
using System;
using System.Windows.Forms;
using Chess.Controlleurs;

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
            // Instanciation du contrôleur et démarrage de l'application
            var jeuController = new JeuController();
            jeuController.DemarrerApplication();
           
        }
        
    }
}

