using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Lab2
{
    struct Grid1D
    {
        public float Step { get; set; }
        public int Num { get; set; }

        public Grid1D(float step, int num)
        {
            Step = step;
            Num = num;
        }

        public override string ToString()
        {
            return Step.ToString() + " " + Num.ToString();
        }

        public string ToString(string format)
        {
            return Step.ToString(format) + " " + Num.ToString();
        }
    }
}
