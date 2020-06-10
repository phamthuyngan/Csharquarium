using Csharquarium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Csharquarium
{
    class Game
    {
        private Aquarium scene;
        private int turns;

        public Game()
        {
            turns = 0;
            scene = new Aquarium();
        }

        public void Render()
        {
            WriteLine("Turn " + turns);
            WriteLine("You've got " + scene.AlgaList.Count() + " algas");
            WriteLine("You've got " + scene.FishList.Count() + " fishes");
            foreach (Fish fish in scene.FishList) //show the stats of the fishes
            {
                WriteLine(fish.name + " / " + fish.Gender + " / PV : " + fish.PV + " / Age : " + fish.Age + " / Specie : " + fish.GetType().ToString());
            }
        }
        public void PassTurn()
        {
            Render();
            scene.ExecuteActions();
            turns++;
        }
        public void AddAlga()
        {
            scene.AddAlga();
        }
        public void AddFish(string name, Genders gender)
        {
            scene.AddFish(name, gender);
        }
        public void AddFish(string name)
        {
            scene.AddFish(name);
        }
    }
}
