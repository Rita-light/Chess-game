using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Chess.Controlleurs;

namespace Chess.Modèles
{

    public class Gestionnaire
    {
        private JeuController controller;
        public List<Joueur> listJoueurs { get; private set; } = new List<Joueur>();
        public List<Partie> listeParties { get; private set; } = new List<Partie>();
        public List<Score> listeScores { get; private set; } = new List<Score>();
        public Partie partieActuelle { get; set; }

        private static String fichierJoueurs = @"Joueurs.txt";
        private static String fichierScores = @"Scores.txt";

        public Gestionnaire(JeuController controller)
        {
            this.controller = controller;
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
            var nouvellePartie = new Partie(Joueur.FromString(joueurs[0]), Joueur.FromString(joueurs[1]), this);
            listeParties.Add(nouvellePartie);
            partieActuelle = nouvellePartie;

            return partieActuelle.ID;
        }

        public (String, String) ObtenirNomJoueur()
        {
            return (partieActuelle.JoueurBlanc.Nom, partieActuelle.JoueurNoir.Nom);
        }
        
        public (int, int) ObtenirPoint()
        {
            return (partieActuelle.PointBlanc, partieActuelle.PointNoir);
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
            Score score = new Score(joueur);
            listeScores.Add(score);
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
        public int ObtenirId()
        {
            return partieActuelle != null ? partieActuelle.ID : -1; // Retourne -1 si aucune partie n'est définie
        }

        
        public void AfficherMessageErreur( String message )
        {
              controller.AfficherMessageErreur(message);
        }
        public void AfficherMessage( String message )
        {
            controller.AfficherMessage(message);
        }
        
        public void QuitterProgramme()
        {
            // Vérifier si toutes les parties sont terminées
            foreach (var partie in listeParties)
            {
                if (!partie.EstTermine)
                { 
                    Console.WriteLine($"La partie {partie.ID} n'est pas terminée. Elle sera fermée automatiquement.");
                    partie.EstTermine = true;
                    partie.TerminerPartie();
                }
            }
            //ajuster Classement 
            AjusterClassement();
            // Sauvegarder les données
            SauvegarderTout();

            // Signaler que le gestionnaire a terminé
            MessageBox.Show("Données sauvegardées. Le programme peut maintenant être fermé.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AjusterScore(int joueurID, int victoire, int defaite, int partNull, int point)
        {
            // Rechercher le score correspondant au joueur dans la liste
            var scoreJoueur = listeScores.FirstOrDefault(s => s.Joueur.JoueurID == joueurID);

            if (scoreJoueur != null)
            {
                // Appeler la méthode AjusterScore de la classe Score
                scoreJoueur.AjusterScore(scoreJoueur.Joueur ,victoire, defaite, partNull, point);
            }
            else
            {
                Console.WriteLine($"Aucun score trouvé pour le joueur avec l'ID {joueurID}.");
            }
        }
        
        public void AjusterClassement()
        {
            // Trier la liste des scores par points (ordre décroissant)
            var scoresTries = listeScores.OrderByDescending(s => s.Points).ToList();

            // Mettre à jour le classement de chaque joueur
            for (int i = 0; i < scoresTries.Count; i++)
            {
                scoresTries[i].Joueur.Classement = i + 1; // Classement commence à 1
            }

            Console.WriteLine("Le classement a été mis à jour.");
        }
        

    }

}