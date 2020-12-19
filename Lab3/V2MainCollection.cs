using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.ComponentModel;

namespace Lab3
{
    class V2MainCollection : IEnumerable<V2Data>
    {
        private List<V2Data> data;
        public event DataChangedEventHandler DataChanged;
        public void Item_PropertyChanged(object source, PropertyChangedEventArgs e)
        {
            DataChanged(source, new DataChangedEventArgs(ChangeInfo.ItemChanged, ((V2Data)source).Frequency));
        }
        public V2Data this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
                DataChanged(data[index], new DataChangedEventArgs(ChangeInfo.Replace, data[index].Frequency));
            }
        }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        public double AverageMagnitude
        {
            get
            {
                return (from list in data
                        from value in list
                        select value.Value.Magnitude).Average();
            }
        }
        public DataItem Nearest
        {
            get
            {
                double val = (from list in data
                              from value in list
                              select (Math.Abs(value.Value.Magnitude - AverageMagnitude))).Min();
                return (from list in data
                        from value in list
                        where (Math.Abs(value.Value.Magnitude - AverageMagnitude) == val)
                        select value).First();
            }
        }
        public IEnumerable<Vector2> Common
        {
            get
            {
                try
                {
                    V2DataCollection first = (V2DataCollection)(from list in data
                                                                where list is V2DataCollection
                                                                select list).First();
                    var collections = from list in data
                                      where list is V2DataCollection
                                      select list;
                    return from vector in first
                           where collections.All(list => (from item in list
                                                   select item.Coords).Contains(vector.Coords))
                           select vector.Coords;
                }
                catch(System.InvalidOperationException)
                {
                    return null;
                }
            }
        }
        public List<V2Data> Data
        {
            get
            {
                return data;
            }
        }
        public void Add(V2Data item)
        {
            item.PropertyChanged += Item_PropertyChanged;
            if (data == null)
            {
                data = new List<V2Data>();
            }
            data.Add(item);
            DataChanged(item, new DataChangedEventArgs(ChangeInfo.Add, item.Frequency));
        }
        public bool Remove(string id, double w)
        {
            bool ans = false;
            for (int i = Count - 1; i >= 0; --i)
            {
                if ((String.Compare(id, data[i].Info) == 0) && (w == data[i].Frequency))
                {
                    data[i].PropertyChanged -= Item_PropertyChanged;
                    ans = true;
                    DataChanged(data[i], new DataChangedEventArgs(ChangeInfo.Remove, data[i].Frequency));
                    data.RemoveAt(i);
                }
            }
            return ans;
        }
        public void AddDefaults()
        {
            Grid1D grid1 = new Grid1D(1, 2);
            Grid1D grid2 = new Grid1D(1, 2);
            V2DataOnGrid tmp1 = new V2DataOnGrid("Info1", 100, grid1, grid2);
            tmp1.Values = new Complex[grid1.Num, grid2.Num];
            for (int i = 0; i < grid1.Num; ++i)
            {
                for (int j = 0; j < grid2.Num; ++j)
                {
                    tmp1.Values[i, j] = new Complex(i * 0.5, j * 0.2);
                }
            }
            tmp1.PropertyChanged += Item_PropertyChanged;
            V2DataCollection tmp2 = (V2DataCollection)new V2DataOnGrid("input.txt");
            tmp2.PropertyChanged += Item_PropertyChanged;
            V2DataOnGrid tmp3 = new V2DataOnGrid("default.txt");
            tmp3.PropertyChanged += Item_PropertyChanged;
            V2DataCollection tmp4 = new V2DataCollection("Info4", 150);
            tmp4.PropertyChanged += Item_PropertyChanged;
            if (data == null)
            {
                data = new List<V2Data>();
            }
            data.Add(tmp1);
            data.Add(tmp2);
            data.Add(tmp3);
            data.Add(tmp4);
        }
        public override string ToString()
        {
            string str = "";
            foreach (V2Data value in data)
            {
                str += value.ToString();
            }
            return str;
        }

        public string ToLongString(string format)
        {
            string str = "";
            foreach (V2Data value in data)
            {
                str += value.ToLongString(format);
            }
            return str;
        }

        public IEnumerator<V2Data> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
