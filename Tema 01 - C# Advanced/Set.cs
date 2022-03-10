using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema01_academy
{
    public class Set<T>
    {
        List<T> list = new List<T>();

        public void Insert(T item)
        {
            if (Contains(item))
            {
                throw new Exception("Setul nu poate contine valori duplicat!");
            }
            else
            {
                list.Add(item);
            }

        }
        public void Remove(T item)
        {
            list.Remove(item);

        }
        public bool Contains(T item)
        {
            foreach (T item2 in list)
            {
                if (item2.Equals(item))
                    return true;

            }
            return false;
        }
        public void Display()
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
        public Set<T> Merge(Set<T> other)
        {
            foreach (T item in other.list)
            {
                if (Contains(item))
                {
                    throw new Exception("Setul rezultat nu poate contine valori duplicat!");

                }
            }
            list.AddRange(other.list);
            return this;
        }
        public Set<T> Filter(Predicate<T> predicate)
        {
            Set<T> subset = new Set<T>();
            subset.list = list.FindAll(predicate);
            subset.Display();
            return subset;
        }
        public List<T> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }

    }
}
