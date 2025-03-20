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

        public void AjouterPoints(int points)
        {
            Points += points;
        }

        public override string ToString()
        {
            return $"{Joueur.Nom}: {Points} points";
        }
    }
}
