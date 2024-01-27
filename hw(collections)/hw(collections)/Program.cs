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
            Game game = new Game("Dima", "Tim");
            game.HandingOutCards();
            game.ShufflingCards();
            game.StartGame();
        }
    }
}