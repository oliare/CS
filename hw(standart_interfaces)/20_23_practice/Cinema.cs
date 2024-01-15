using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _20_23_practice
{
    public enum Genre
    {
        Comedy, Horror, Adventure, Action, Fantasy, Drama, Documentary
    }

    internal class Cinema : IEnumerable
    {
        public Movie[] movies;
        public string Address { get; set; }
        public IEnumerator GetEnumerator()
        {
            foreach (Movie item in movies)
            {
                yield return item;
            }
        }
        public void Sort()
        {
            Array.Sort(movies);
        }
        public void Sort(IComparer comparer)
        {
            Array.Sort(movies, comparer);
        }
        public override string ToString()
        {
            return $"{String.Join<Movie>("\n\n\t----------\n", movies)}";
        }
    }

}
