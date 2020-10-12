using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    struct DataItem
    {
        public System.Numerics.Vector2 Coords { get; set; }
        public System.Numerics.Complex Value { get; set; }

        public DataItem(System.Numerics.Vector2 coords, System.Numerics.Complex value)
        {
            Coords = coords;
            Value = value;
        }

        public override string ToString()
        {
            return Coords.ToString() + ": " + Value.ToString();
        }
    }
}
