using System;
using System.Numerics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid1D grid1 = new Grid1D(2, 12);
            Grid1D grid2 = new Grid1D(1, 6);
            V2DataOnGrid dataOnGrid = new V2DataOnGrid("Test object", 6, grid1, grid2);
            dataOnGrid.InitRandom(0, 200);
            Console.WriteLine(dataOnGrid.ToLongString());
            V2DataCollection dataCollection = (V2DataCollection)dataOnGrid;
            Console.WriteLine(dataCollection.ToLongString());

            V2MainCollection collection1 = new V2MainCollection();
            collection1.AddDefaults();
            Console.WriteLine(collection1.ToString());

            V2MainCollection collection2 = new V2MainCollection();
            collection2.AddDefaults();
            foreach (V2Data value in collection2)
            {
                foreach (Complex z in value.NearAverage(50))
                {
                    Console.Write(z.ToString() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
