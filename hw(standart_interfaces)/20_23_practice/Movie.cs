using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_23_practice
{
    class Movie : IComparable<Movie>, ICloneable
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
        public int CompareTo(Movie obj)
        {
            return Rating.CompareTo(obj.Rating);
        }
        public override string ToString()
        {
            return $"\nMovie title: {Name}\nDescription: {Description}\n{Director}\nCountry: {Country}" +
                $"\nYear   : {Year}\nRating : {Rating}\nGenre  : {Genre}";
        }
    }
    class CompareByRating : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }
    class CompareByYear : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
}