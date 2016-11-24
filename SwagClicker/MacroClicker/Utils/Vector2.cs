using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagClicker.Utils
{
    struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 ZERO = new Vector2(0, 0);

        public override string ToString()
        {
            return $"{X};{Y}";
        }

        public static Vector2 fromString(string line)
        {
            string[] args = line.Split(';');
            return new Vector2(int.Parse(args[0]), int.Parse(args[1]));
        }
    }
}
