using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            V2MainCollection dataItems = new V2MainCollection();
            dataItems.DataChanged += DataItems_DataChanged;
            V2DataCollection tmp1 = new V2DataCollection("Info1", 100);
            V2DataCollection tmp2 = new V2DataCollection("Info2", 125);
            V2DataCollection tmp3 = new V2DataCollection("Info3", 150);
            dataItems.Add(tmp1);
            dataItems.Add(tmp2);
            dataItems[1] = tmp3;
            dataItems[0].Frequency = 250;
            dataItems.Remove("Info3", 150);
        }

        private static void DataItems_DataChanged(object source, DataChangedEventArgs args)
        {
            Console.WriteLine(args);
        }
    }
}
