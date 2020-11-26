using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab2
{
    class V2DataCollection : V2Data, IEnumerable<DataItem>
    {
        public List<DataItem> dataItems { get; set; }

        public V2DataCollection(string info, double freq)
           : base(info, freq)
        {
            dataItems = new List<DataItem>();
        }

        public void InitRandom(int nItems, float xmax, float ymax, double minValue, double maxValue)
        {
            Random rnd = new Random();
            DataItem curr = new DataItem();
            for (int i = 0; i < nItems; ++i)
            {
                Vector2 tmp = new Vector2((float)(rnd.NextDouble() * xmax), (float)(rnd.NextDouble() * ymax));
                curr.Coords = tmp;
                curr.Value = new Complex(rnd.NextDouble() * (maxValue - minValue) + minValue,
                        rnd.NextDouble() * (maxValue - minValue) + minValue);
                dataItems.Add(curr);
            }
        }

        public override Complex[] NearAverage(float eps)
        {
            List<Complex> ans = new List<Complex>();
            double mean = 0;
            int num = dataItems.Count;
            foreach (DataItem value in dataItems)
            {
                mean += value.Value.Real;
            }
            mean /= num;
            foreach (DataItem value in dataItems)
            {
                if (Math.Abs(value.Value.Real - mean) <= eps)
                {
                    ans.Add(value.Value);
                }
            }
            return ans.ToArray();
        }

        public override string ToString()
        {
            return "V2DataCollection: " + Info + ", frequency: " + Frequency.ToString() + " "
               + dataItems.Count.ToString() + "\n";
        }

        public override string ToLongString()
        {
            String str = "V2DataCollection: " + Info + ", frequency: " + Frequency.ToString() + " "
               + dataItems.Count.ToString() + "\n";
            foreach (DataItem value in dataItems)
            {
                str += "(" + value.Coords.X.ToString() + ", " + value.Coords.Y.ToString()
                    + "): " + value.Value.ToString() + "\n";
            }
            return str;
        }

        public override IEnumerator<DataItem> GetEnumerator()
        {
            return dataItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToLongString(string format)
        {
            String str = "V2DataCollection: " + Info + ", frequency: " + Frequency.ToString(format) + "\n";
            foreach (DataItem value in dataItems)
            {
                str += "(" + value.Coords.X.ToString(format) + ", " + value.Coords.Y.ToString(format)
                    + "): " + value.Value.ToString(format) + ", "+ value.Value.Magnitude.ToString(format) + "\n";
            }
            return str;
        }
    }
}
