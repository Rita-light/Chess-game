using System;

namespace Chess.Modèles
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            if (x < 0 || x > 7)
                throw new ArgumentOutOfRangeException(nameof(x), "X doit être entre 0 et 7.");
            if (y < 0 || y > 7)
                throw new ArgumentOutOfRangeException(nameof(y), "Y doit être entre 0 et 7.");
            X = x;
            Y = y;
        }

        public Position() : this(0, 0) { }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Position))
                return false;

            Position autre = (Position)obj;
            return X == autre.X && Y == autre.Y;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}
