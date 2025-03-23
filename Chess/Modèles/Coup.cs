using System;

namespace Chess.Modèles
{
    public class Coup
    {
        public Position Depart { get; private set; }
        public Position Destination { get; private set; }

        public Coup(Position depart, Position destination)
        {
            if (depart == null)
                throw new ArgumentNullException(nameof(depart));
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));
            Depart = depart;
            Destination = destination;
        }

        public Coup() : this(new Position(0, 0), new Position(0, 0)) { }

        //-------------------------------------------------------------------------
        // Overrides
        //-------------------------------------------------------------------------

        public override string ToString()
        {
            return $"Coup de {Depart} vers {Destination}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            Coup autre = (Coup)obj;
            return Depart.Equals(autre.Depart) && Destination.Equals(autre.Destination);
        }

        public override int GetHashCode()
        {
            return (Depart, Destination).GetHashCode();
        }
    }
}
