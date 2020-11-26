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
            V2MainCollection colletion1 = new V2MainCollection();
            colletion1.AddDefaults();
            Console.WriteLine(colletion1.ToLongString("F4"));
            Console.WriteLine("Average magnitude: " + colletion1.AverageMagnitude.ToString("F4") + "\n");
            Console.WriteLine("DataItem with magnitude nearest to the average: " + colletion1.Nearest.ToString("F4") + "\n");
            Console.WriteLine("All coordinates:\n");
            foreach (Vector2 value in colletion1.Common)
            {
                Console.WriteLine(value.ToString("F4"));
            }
        }
    }
}
