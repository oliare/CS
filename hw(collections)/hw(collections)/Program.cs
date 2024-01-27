using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_collections_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Dima");
            Player p2 = new Player("Tim");

            Game game = new Game(p1, p2);
            game.HandingOutCards();
            game.ShufflingCards();
            game.StartGame();
        }
    }
}