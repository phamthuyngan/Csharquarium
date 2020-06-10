using Csharquarium.Models;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();


            for (int i = 0; i < 1; i++)
            {
                game.AddAlga();
            }
            game.AddFish("John Doe", Genders.Male);
            game.AddFish("Matrix", Genders.Female);
            game.AddFish("Truc", Genders.Female);
            game.AddFish("Machin", Genders.Male);
            game.AddFish("Macro", Genders.Male);
            game.AddFish("Bar", Genders.Female);
            game.AddFish("Narval", Genders.Male);
            game.AddFish("Gupi", Genders.Female);
            game.AddFish("Test");

            do
            {
                game.PassTurn();
            } while (ReadLine() != "x");

        }
    }
}
