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
            this.joueurID = ++dernierID;
            this.nom = nom;
            this.victoire = 0;
            this.defaite = 0;
            this.partNulle = 0;
            this.classement = 0;
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
            get { return this.nom;}
            set { this.nom = value; }
        }
        
        public int Victoire
        {
            get { return this.victoire;}
            set { this.victoire = value; }
        }

        public int Defaite
        {
            get { return this.defaite; }
            set { this.defaite = value; }
        }

        public int Classement
        {
            get { return this.classement; }
            set { this.classement = value; }
        }

        public int PartNulle
        {
            get { return this.partNulle; }
            set { this.partNulle = value; }
        }

        public int Parties
        {
            get { return this.victoire + this.defaite; }
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
