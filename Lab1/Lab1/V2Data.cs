using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Markup;

namespace Lab1
{
    abstract class V2Data
    {
        public string Info { get; set; }
        public double Frequency { get; set; }

        public V2Data(string info, double freq)
        {
            Info = info;
            Frequency = freq;
        }

        public abstract Complex[] NearAverage(float eps);
        public abstract string ToLongString();
        public override string ToString()
        {
            return Info + ", " + "frequency: " + Frequency.ToString();
        }
    }
}
