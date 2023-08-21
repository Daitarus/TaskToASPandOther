using System;
using System.Collections;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    public class MyList<T> : IList<T> where T : IComparable<T>
    {
        private T[] contents = new T[8];

        public int Count { get; private set; }

        public bool IsReadOnly { get; } = false;

        public MyList() : this(8) { }
        public MyList(int capacity)
        {
            contents = new T[capacity];
            Count = 0;
        }

        public T this[int index] 
        { 
            get
            {
                if (index >= Count) throw new IndexOutOfRangeException();
                else
                    return contents[index];
            }
            set
            {
                if (index >= Count) throw new IndexOutOfRangeException();
                else
                    contents[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for(int i = 0; i < Count; i++)
            {
                if (contents[i].Equals(item)) 
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    contents[i] = contents[i + 1];
                }
                Count--;
            }
            else
                throw new IndexOutOfRangeException();
        }

        public void Add(T item)
        {
            if (Count == contents.Length) 
                IncreaseLength();

            contents[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < Count; i++)
            {
                if (contents[i].Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(contents[i], index++);
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        public void Sort()
        {
            Sort(0, Count - 1);
        }
        private void Sort(int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = Partition(startIndex, endIndex);
                Sort(startIndex, pivotIndex - 1);
                Sort(pivotIndex + 1, endIndex);
            }
        }
        private int Partition(int startIndex, int endIndex)
        {
            var pivot = startIndex - 1;
            for (var i = startIndex; i < endIndex; i++)
            {
                if (contents[i].CompareTo(contents[endIndex]) < 0)
                {
                    pivot++;
                    Swap(ref contents[pivot], ref contents[i]);
                }
            }

            pivot++;
            Swap(ref contents[pivot], ref contents[endIndex]);
            return pivot;
        }
        private void Swap(ref T x, ref T y)
        {
            var t = x;
            x = y;
            y = t;
        }

        private void IncreaseLength()
        {
            T[] newContents = new T[contents.Length + 8];
            for(int i = 0; i < contents.Length; i++)
            {
                newContents[i] = contents[i];
            }
            contents = newContents;
        }
    }
}
