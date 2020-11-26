using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Markup;

namespace Lab2
{
    abstract class V2Data: IEnumerable<DataItem>
    {
        public string Info { get; set; }
        public double Frequency { get; set; }

        public V2Data() { }

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

        public abstract string ToLongString(string format);

        public abstract IEnumerator<DataItem> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
