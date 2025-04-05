using System;

namespace Chess.Modèles
{
    public class Score
    {
        public Joueur Joueur { get; private set; }
        public int Points { get; private set; }
    
        public Score(Joueur joueur, int points = 0)
        {
            Joueur = joueur ?? throw new ArgumentNullException(nameof(joueur));
            Points = points;
        }

        public void AjusterScore(Joueur joueur, int victoire, int defaite, int partNulle, int points)
        {
            // Mettre à jour les statistiques du joueur
            joueur.Victoire += victoire;
            joueur.Defaite += defaite;
            joueur.PartNulle += partNulle;

            // Ajouter les points au score actuel
            Points += points;
        }
        
        public override string ToString()
        { 
            return $"{Joueur};{Points}";
        }

        public static Score FromString(string ligne)
        {
            if (string.IsNullOrWhiteSpace(ligne))
            {
                throw new ArgumentException("La ligne est vide ou invalide.");
            }

            var parts = ligne.Split(';');
            if (parts.Length != 7) // Vérifie qu'il y a exactement 7 parties (6 pour le joueur et 1 pour le score)
            {
                throw new FormatException($"Ligne mal formatée : {ligne}");
            }

            try
            {
                // Construire un joueur à partir des 6 premières parties
                var joueur = new Joueur(
                    int.Parse(parts[0]),  // JoueurID
                    parts[1],             // Nom
                    int.Parse(parts[2]),  // Victoire
                    int.Parse(parts[3]),  // Défaite
                    int.Parse(parts[4]),  // PartNulle
                    int.Parse(parts[5])   // Classement
                );

                // Obtenir le score à partir de la 7ème partie
                var points = int.Parse(parts[6]);

                // Retourner un nouvel objet Score
                return new Score(joueur, points);
            }
            catch (Exception ex)
            {
                throw new FormatException($"Erreur lors de la conversion de la ligne '{ligne}': {ex.Message}");
            }
        }
    }
    
}
