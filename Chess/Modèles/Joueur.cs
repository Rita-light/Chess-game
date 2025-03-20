using System;

namespace Chess.Modèles
{
    public class Joueur
    {
        public string Nom { get; private set; }

        public Joueur(string nom)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom du joueur ne peut pas être vide.");

            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Joueur autre = (Joueur)obj;
            return Nom.Equals(autre.Nom, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
