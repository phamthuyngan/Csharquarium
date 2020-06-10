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
            Aquarium aqua = new Aquarium();
            for (int i = 0; i < 1; i++)
            {
                aqua.AddAlga();
            }
            aqua.AddFish("John Doe", Genders.Male);
            aqua.AddFish("Matrix", Genders.Female);
            aqua.AddFish("Truc", Genders.Female);
            aqua.AddFish("Machin", Genders.Male);
            aqua.AddFish("Macro", Genders.Male);
            aqua.AddFish("Bar", Genders.Female);
            aqua.AddFish("Narval", Genders.Male);
            aqua.AddFish("Gupi", Genders.Female);

            do
            {
                aqua.PassTurn();
            } while (ReadLine() != "x");

        }
    }
}
