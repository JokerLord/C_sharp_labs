using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Lab3
{
    struct DataItem
    {
        public Vector2 Coords { get; set; }
        public Complex Value { get; set; }

        public DataItem(Vector2 coords, Complex value)
        {
            Coords = coords;
            Value = value;
        }

        public override string ToString()
        {
            return Coords.ToString() + ": " + Value.ToString();
        }

        public string ToString(string format)
        {
            return Coords.ToString(format) + ": " + Value.ToString(format) + ", " + Value.Magnitude.ToString(format);
        }
    }
}
