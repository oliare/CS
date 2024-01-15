using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_23_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Director d1 = new Director("Steven", "Spielberg", 30, false, "some award", new DateTime(1946, 12, 18));
            Director d2 = new Director("David", "Lynch", 26, true, "some award", new DateTime(1946, 1, 20));
            Director d3 = new Director("Martin", "Scorsese", 23, true, "some award", new DateTime(1942, 4, 17));

            Movie m1 = new Movie("The Fabelmans ", "description", d1, "USA", 2022, 7.4, Genre.Drama);
            Movie m2 = new Movie("Eraserhead", "description", d2, "USA", 1977, 8.5, Genre.Fantasy);
            Movie m3 = new Movie("Shutter Island", "description", d2, "USA", 2010, 8.6, Genre.Horror);

            Cinema cinema = new Cinema { 
                movies = new Movie[] { m1, m2, m3} 
            };

            Console.WriteLine(cinema);

            Console.WriteLine("\n ======= Sorting by Rating =======");
            cinema.Sort(new CompareByRating());
            Console.WriteLine(cinema);

            Console.WriteLine("\n ======= Sorting by Year =======");
            cinema.Sort(new CompareByYear());
            Console.WriteLine(cinema);

            Console.WriteLine();
        }

    }
}
