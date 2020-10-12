using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
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
    }
}
