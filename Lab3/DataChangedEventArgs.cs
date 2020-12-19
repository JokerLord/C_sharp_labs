using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    enum ChangeInfo
    {
        ItemChanged,
        Add,
        Remove,
        Replace
    }
    delegate void DataChangedEventHandler(object source, DataChangedEventArgs args);
    class DataChangedEventArgs
    {
        public ChangeInfo Info { get; set; }
        public double Number { get; set; }
        public DataChangedEventArgs(ChangeInfo info, double a)
        {
            Info = info;
            Number = a;
        }
        public override string ToString()
        {
            return "Info: " + Info + ", number: " + Number.ToString(); 
        }
    }
}
