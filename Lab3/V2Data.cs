using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Markup;
using System.ComponentModel;

namespace Lab3
{
    abstract class V2Data: IEnumerable<DataItem>, INotifyPropertyChanged
    {
        private string info;
        private double frequency;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        public double Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
                OnPropertyChanged("Frequency");
            }
        }
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
