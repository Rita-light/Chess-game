using System;

namespace Chess.Modèles
{
    public class Joueur
    {
        // Champ statique pour suivre le dernier ID généré
        private static int dernierID = 0;

        private int joueurID;
        private string nom;
        private int victoire;
        private int defaite;
        private int partNulle;
        private int classement;


        public Joueur(string nom)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom du joueur ne peut pas être vide.");
            joueurID = ++dernierID;
            this.nom = nom;
            victoire = 0;
            defaite = 0;
            partNulle = 0;
            classement = 0;
        }
        public Joueur(int joueurId, string nom, int victoire, int defaite, int partNulle, int classement)
        {
            // Génération automatique de l'ID
            JoueurID = joueurId;
            Nom = nom;
            Victoire = victoire;
            Defaite = defaite;
            PartNulle = partNulle;
            Classement = classement;
        }

        public int JoueurID
        {
            get => joueurID;
            set => joueurID = value;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public int Victoire
        {
            get { return victoire; }
            set { victoire = value; }
        }

        public int Defaite
        {
            get { return defaite; }
            set { defaite = value; }
        }

        public int Classement
        {
            get { return classement; }
            set { classement = value; }
        }

        public int PartNulle
        {
            get { return partNulle; }
            set { partNulle = value; }
        }

        public int Parties
        {
            get { return victoire + defaite; }
        }


        // Méthode ToString - Convertit l'objet en chaîne de caractères
        public override string ToString()
        {
            return $"{JoueurID};{Nom};{Victoire};{Defaite};{PartNulle};{Classement}";
        }

        public static Joueur FromString(string data)
        {
            var parts = data.Split(';');
            return new Joueur
            (
                int.Parse(parts[0]),
                parts[1],
                int.Parse(parts[2]),
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                int.Parse(parts[5])
            );
        }

        
        // Méthode Equals pour comparer deux joueurs
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Joueur autreJoueur = (Joueur)obj;

            // Comparaison basée sur l'ID du joueur
            return this.joueurID == autreJoueur.joueurID;
        }


        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }


    }
}
