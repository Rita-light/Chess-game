using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chess.Modèles
{

    public class Gestionnaire
    {
        public List<Joueur> listJoueurs { get; private set; } = new List<Joueur>();
        public List<Partie> listeParties { get; private set; } = new List<Partie>();
        public List<Score> listeScores { get; private set; } = new List<Score>();
        public Partie partieActuelle { get; set; }

        private static String fichierJoueurs = @"Joueurs.txt";
        private static String fichierScores = @"Scores.txt";

        public Gestionnaire()
        {
            ChargerTout();
            InitialiserDernierID();
        }

        private void InitialiserDernierID()
        {
            if (listJoueurs.Any())
            {
                Joueur.dernierID = listJoueurs.Max(j => j.JoueurID);
            } else
            {
                Joueur.dernierID = 0;
            }
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

        public int CreerNouvellePartie(List<String> joueurs)
        {
            var nouvellePartie = new Partie(Joueur.FromString(joueurs[0]), Joueur.FromString(joueurs[1]));
            listeParties.Add(nouvellePartie);
            partieActuelle = nouvellePartie;

            return partieActuelle.ID;
        }

        public (String, String) ObtenirNomJoueur()
        {
            return (partieActuelle.JoueurBlanc.Nom, partieActuelle.JoueurNoir.Nom);
        }

        public String ObtenirPlateauActuel()
        {
            return partieActuelle.Plateau.ToString();
        }

        public Partie ObtenirPartieParId(int idPartie)
        {
            foreach (var partie in listeParties)
            {
                if (partie.ID == idPartie)
                {
                    return partie; // Renvoie la partie correspondant à l'ID
                }
            }
            return null; // Si aucune partie n'est trouvée
        }

        public Boolean jouerCoup(int departX, int departY, int destinationX, int destinationY, int partieID)
        {
            Position depart = new Position(departX, departY);
            Position destination = new Position(destinationX, destinationY);
            Coup coup = new Coup(depart, destination);
            partieActuelle = ObtenirPartieParId(partieID);
            return partieActuelle.ExecuterCoup(coup);
        }

        public void CreerNouveauJoueur(String nomJoueur)
        {
            Joueur joueur = new Joueur(nomJoueur);
            listJoueurs.Add(joueur);
        }
        
        public List<string> ObtenirScoresFormatString()
        {
            List<string> scores = new List<string>();
            foreach (var score in listeScores)
            {
                scores.Add(score.ToString()); // Utilise ToString() de Score
            }
            return scores;
        }
        public List<string> ObtenirJoueurFormatString()
        {
            List<string> joueurs = new List<string>();
            foreach (var joueur in listJoueurs)
            {
                joueurs.Add(joueur.ToString()); // Utilise ToString() de Score
            }
            return joueurs;
        }


    }

}