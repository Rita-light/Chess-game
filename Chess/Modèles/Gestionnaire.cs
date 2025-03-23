using System;
using System.Collections.Generic;
using System.IO;

namespace Chess.Modèles
{
    
    public class Gestionnaire
    {
        public List<Joueur> listJoueurs { get; private set; } = new List<Joueur>();
        public List<Partie> listeParties { get; private set; } = new List<Partie>();
        public List<Score> listeScores { get; private set; } = new List<Score>();
        public Partie partieActuelle { get; set; }

        private string fichierJoueurs = @"Joueurs.txt";
        private string fichierScores = @"Scores.txt";

        public Gestionnaire()
        {
           ChargerTout();
        }

        // methode pour chatger le fichier
        private void Charger<T>(string fichier, List<T> liste, Func<string, T> fromString)
        {
            if (File.Exists(fichier))
            {
                try
                {
                    foreach (var ligne in File.ReadAllLines(fichier))
                    {
                        liste.Add(fromString(ligne));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erreur lors du chargement du fichier {fichier}: {e.Message}");
                    throw;
                }
            }
            
        }

        // sauvegarde
        private void Sauvegarder<T>(string fichier, List<T> liste)
        {
            try
            {
                File.WriteAllLines(fichier, liste.ConvertAll(item => item.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur lors du chargement du fichier {fichier}: {e.Message}");
                throw;
            }
        }

        public void ChargerTout()
        {
            Charger(fichierJoueurs, listJoueurs, Joueur.FromString);
            Charger(fichierScores, listeScores, Score.FromString);
        }

        public void SauvegarderTout()
        {
            Sauvegarder(fichierJoueurs, listJoueurs);
            Sauvegarder(fichierScores, listeScores);
        }
        
        
        public void AjouterPartie(Partie partie)
        {
            listeParties.Add(partie);
        }


        public Boolean jouerCoup(Coup coup)
        {
            return partieActuelle.ExecuterCoup(coup);
        }
        
       

        
    }

}