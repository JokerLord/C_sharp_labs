using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class V2MainCollection : IEnumerable<V2Data>
    {
        private List<V2Data> data;
        public int Count
        {
            get
            {
                return data.Count;
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
            data.Add(item);
        }
        bool Remove(string id, double w)
        {
            bool ans = false;
            for (int i = Count - 1; i >= 0; --i)
            {
                if ((String.Compare(id, data[i].Info) == 0) && (w == data[i].Frequency))
                {
                    ans = true;
                    data.RemoveAt(i);
                }
            }
            return ans;
        }
        public void AddDefaults()
        {
            Grid1D grid1 = new Grid1D(1, 5);
            Grid1D grid2 = new Grid1D(1, 5);
            V2DataOnGrid tmp1 = new V2DataOnGrid("Info1", 100, grid1, grid2);
            tmp1.InitRandom(0, 100);
            V2DataCollection tmp2 = (V2DataCollection)tmp1;
            V2DataCollection tmp3 = new V2DataCollection("Info3", 150);
            tmp3.InitRandom(7, 15, 15, 0, 150);
            if (data == null)
            {
                data = new List<V2Data>();
            }
            data.Add(tmp1);
            data.Add(tmp2);
            data.Add(tmp3);
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
        public IEnumerator<V2Data> GetEnumerator()
        {
            return new V2Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class V2Enumerator: IEnumerator<V2Data>
    {
        private int current = -1;
        public V2MainCollection box;
        public V2Enumerator(V2MainCollection data)
        {
            this.box = data;
        }
        public V2Data Current
        {
            get
            {
                if (current == -1 || current >= box.Count)
                {
                    throw new InvalidOperationException();
                }
                return box.Data[current];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (current < box.Count - 1)
            {
                ++current;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            current = -1;
        }
        public void Dispose() { }
    }
}
