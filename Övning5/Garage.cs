using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5
{
    public class Garage<T>: IEnumerable<T> where T: IVehicle
    {
        private int capacity;
        private int current;
        private T?[] spaces;

        public int Capacity => capacity;


        public bool IsFull => current >= capacity;

        public Garage(int capacity)
        {
            //Validate
            this.capacity = capacity;
            spaces = new T[capacity];
        }

        public bool Add(T input)
        {
            if (IsFull)
            {
                return false;
            }
            int firstEmpty = Array.IndexOf(spaces, null);
            //Is -1?
            spaces[firstEmpty] = input;
            current++;
            return true;
        }

        //public T this[int index] => spaces[index];
        public T? this[int index]
        {
            get
            {
                return spaces[index];
            }
            private set
            {
                spaces[index] = value;
            }
        }

        public bool Unpark(string regnr)
        {
            for(var i = 0; i < spaces.Length; i++)
            {
                if(spaces[i] != null && spaces[i]?.RegNr.ToLower() == regnr.ToLower())
                {
                    spaces[i] = default;// null;  // här körs fordonet ut
                    current--;
                    return true;
                }
            }
            return false;
        }

        //public IQueryable<T> GetQuery()
        //{
        //    var query = spaces.Where(p => p != null).AsQueryable();
        //    return query;
        //}

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T? i in spaces)
            {
                if (i != null)
                {
                    yield return i;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
