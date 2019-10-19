using System;
namespace PacEngine.utils
{
    public class Vector
    {
        public static Vector UP => new Vector(0, 1);
        public static Vector DOWN => -UP;
        public static Vector RIGHT => new Vector(1, 0);
        public static Vector LEFT => -RIGHT;

        public int x { get; set; }
        public int y { get; set; }

        public int Magnitude => (int)Math.Sqrt((x * x) + (y * y));
        public Vector Normalized => new Vector(x / Magnitude, y / Magnitude);

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public void Normalize()
        {
            x /= Magnitude;
            y /= Magnitude;
        }

        public static Vector operator -(Vector a)
        {
            a.x = -a.x;
            a.y = -a.y;
            return a;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            a.x -= b.x;
            a.y -= b.y;

            return a;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            a.x += b.x;
            a.y += b.y;

            return a;
        }

        public static Vector operator *(Vector a, int multipier)
        {
            a.x *= multipier;
            a.y *= multipier;

            return a;
        }
    }
}
