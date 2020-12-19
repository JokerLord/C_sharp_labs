using System;
using System.Numerics;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            V2DataOnGrid dataOnGrid = new V2DataOnGrid("input.txt");
            Console.WriteLine(dataOnGrid.ToLongString("F4"));
            V2MainCollection collection1 = new V2MainCollection();
            collection1.AddDefaults();
            Console.WriteLine(collection1.ToLongString("F4"));
            Console.WriteLine("Average magnitude: " + collection1.AverageMagnitude.ToString("F4") + "\n");
            Console.WriteLine("DataItem with magnitude nearest to the average: " + collection1.Nearest.ToString("F4") + "\n");
            Console.WriteLine("Common coordinates:");
            if (collection1.Common != null)
            {
                foreach (Vector2 value in collection1.Common)
                {
                    Console.WriteLine(value.ToString("F4"));
                }
            }
        }
    }
}
