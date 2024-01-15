using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_23_practice
{
    class Movie : IComparable, ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public uint Year { get; set; }
        public double Rating { get; set; }
        public Movie(string name, string description, Director director,
            string country, uint year, double rating, Genre genre)
        {
            Name = name;
            Description = description;
            Director = director;
            Country = country;
            Year = year;
            Rating = rating;
            Genre = genre;
        }
        public object Clone()
        {
            Movie m = new Movie(Name, Description, (Director)Director.Clone(),
                Country, Year, Rating, Genre);
            return m;
        }
        public int CompareTo(object obj)
        {
            if (obj is Movie)
            {
                return Rating.CompareTo((obj as Movie).Rating);
            }
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"\nMovie title: {Name}\nDescription: {Description}\n{Director}\nCountry: {Country}" +
                $"\nYear   : {Year}\nRating : {Rating}\nGenre  : {Genre}";
        }
    }
    class CompareByRating : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Movie && y is Movie)
            {
                return (x as Movie).Rating.CompareTo((y as Movie).Rating);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
    class CompareByYear : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Movie && y is Movie)
            {
                return (x as Movie).Year.CompareTo((y as Movie).Year);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}