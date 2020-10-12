using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1
{
    class V2DataOnGrid : V2Data
    {
        public Grid1D[] Grids { get; set; }
        public Complex[,] Values { get; set; }

        public V2DataOnGrid(string info, double freq, Grid1D grid1, Grid1D grid2)
            : base(info, freq)
        {
            Grids = new Grid1D[2];
            Grids[0] = grid1;
            Grids[1] = grid2;
        }

        public void InitRandom(double minValue, double maxValue)
        {
            Values = new Complex[Grids[0].Num, Grids[1].Num];
            Random rnd = new Random();
            for (int i = 0; i < Grids[0].Num; ++i)
            {
                for (int j = 0; j < Grids[1].Num; ++j)
                {
                    Values[i, j] = new Complex(rnd.NextDouble() * (maxValue - minValue) + minValue,
                        rnd.NextDouble() * (maxValue - minValue) + minValue);
                }
            }
        }

        public static explicit operator V2DataCollection(V2DataOnGrid dataOnGrid)
        {
            V2DataCollection dataCollection = new V2DataCollection(dataOnGrid.Info, dataOnGrid.Frequency);
            DataItem tmp = new DataItem();
            for (int i = 0; i < dataOnGrid.Grids[0].Num; ++i)
            {
                for (int j = 0; j < dataOnGrid.Grids[1].Num; ++j)
                {
                    tmp.Coords = new Vector2(i * dataOnGrid.Grids[0].Step, j * dataOnGrid.Grids[1].Step);
                    tmp.Value = dataOnGrid.Values[i, j];
                    dataCollection.dataItems.Add(tmp);
                }
            }
            return dataCollection;
        }

        public override Complex[] NearAverage(float eps)
        {
            List<Complex> ans = new List<Complex>();
            int num = Grids[0].Num * Grids[1].Num;
            double mean = 0;
            foreach (Complex value in Values)
            {
                mean += value.Real;
            }
            mean /= num;
            foreach (Complex value in Values)
            {
                if (Math.Abs(value.Real - mean) <= eps)
                {
                    ans.Add(value);
                }
            }
            return ans.ToArray();
        }

        public override string ToString()
        {
            return "V2DataOnGrid: " + Info + ", frequency: " + Frequency.ToString()
                + ", Ox: " + Grids[0].ToString() + ", Oy: " + Grids[1].ToString() + "\n";
        }

        public override string ToLongString()
        {
            String str = "V2DataOnGrid: " + Info + ", frequency: " + Frequency.ToString()
                + ", Ox: " + Grids[0].ToString() + ", Oy: " + Grids[1].ToString() + "\n";
            for (int i = 0; i < Grids[0].Num; ++i)
            {
                for (int j = 0; j < Grids[1].Num; ++j)
                {
                    str += "(" + (i * Grids[0].Step).ToString() + ", " + (j * Grids[1].Step).ToString()
                        + "): " + Values[i, j].ToString() + "\n";
                }
            }
            return str;
        }
    }
}
