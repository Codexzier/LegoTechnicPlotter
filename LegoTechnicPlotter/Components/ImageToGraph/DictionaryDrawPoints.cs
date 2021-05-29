using System;
using Microsoft.SPOT;
using System.Collections;

namespace LegoTechnicPlotter.Components.ImageToGraph
{
    public class DictionaryDrawPoints : IDictionary
    {
        private ArrayList _keys = new ArrayList();
        private ArrayList _values = new ArrayList();

        public void Add(object key, object value)
        {
            this._keys.Add(key);
            this._values.Add(value);
        }

        public void Clear()
        {
            this._keys.Clear();
            this._values.Clear();
        }

        public bool Contains(object key)
        {
            foreach (var item in this._keys)
            {
                if (item.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public ICollection Keys
        {
            get { return this._keys; }
        }

        public void Remove(object key)
        {
            var index = this._keys.IndexOf(key);
            this._keys.RemoveAt(index);
            this._values.RemoveAt(index);
        }

        public ICollection Values
        {
            get { return this._values; }
        }

        public object this[object key]
        {
            get
            {
                var index = this._keys.IndexOf(key);
                return this._values[index];
            }
            set
            {
                var index = this._keys.IndexOf(key);
                this._values[index] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this._keys.Count; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
