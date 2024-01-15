using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_23_practice
{
    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint DirectedMovie { get; set; }
        public bool HasOscar { get; set; }
        public string Awards { get; set; }
        public DateTime BirthDate { get; set; }

        public Director(string fname, string lname, uint directedMovie,
            bool hasOscar, string awards, DateTime birthDate)
        {
            FirstName = fname;
            LastName = lname;
            DirectedMovie = directedMovie;
            HasOscar = hasOscar;
            Awards = awards;
            BirthDate = birthDate;
        }
        public object Clone()
        {
            Director d = new Director(FirstName, LastName, DirectedMovie,
                HasOscar, Awards, BirthDate);
            return d;
        }
        public override string ToString()
        {
            return $"Director   : {FirstName} {LastName}\nRealised : {DirectedMovie} movies" +
                $"\nHas Oscar: {HasOscar}\nAwards   : {Awards}\nBirthday : {BirthDate.ToShortDateString()}";
        }
    }
}
