using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Csharquarium.Models
{
    class Aquarium
    {
        private Fish[] fishList;
        private Alga[] algaList;
        private int turn;
        protected static Random RNG = new Random();// RNG for the aquarium

        public Aquarium()
        {
            turn = 0;
            fishList = new Fish[0];
            algaList = new Alga[0];
        }

        public void AddFish(string name, Genders gender) // add fishes to the aquarium
        {
            Fish newFish;
            if (RNG.Next(0, 10) > 3) // choose a random type of fish
            {
                newFish = new Herbivore(name, gender);
            }
            else
            {
                newFish = new Carnivore(name, gender);
            }
            List<Fish> newFishList = fishList.ToList();
            newFishList.Add(newFish);
            fishList = newFishList.ToArray();
        }
        public void AddAlga() //Add algas to the aquarium
        {
            Alga newAlga = new Alga();
            List<Alga> newAlgaList = algaList.ToList();
            newAlgaList.Add(newAlga);
            algaList = newAlgaList.ToArray();
        }

        public void ShowFish()
        {
            foreach (Fish fish in fishList) //show the stats of the fishes
            {
                WriteLine(fish.name + " / " + fish.Gender + " / " + fish.GetType() + " / PV : " + fish.PV + " / Age : " + fish.Age + " / Specie : " + fish.Specie);
            }
        }
        public void InflictDamage() //choose target from array
        {
            foreach (Fish fish in fishList)
            {
                if (fish.PV < 5 & fish.Died == false)
                {
                    if (fish is Herbivore herb)
                    {
                        if (algaList.Length > 0)
                        {
                            herb.ChooseTarget(algaList);
                            herb.Eat(algaList[fish.Target]);
                        }
                    }
                    else if (fish is Carnivore carn)
                    {
                        carn.ChooseTarget(fishList);
                        carn.Eat(fishList[carn.Target]);
                    }
                }
            }
        }
        public void RemoveDead()
        {
            foreach (Alga alga in algaList) //add the age of the fish
            {
                alga.AddAge();
            }
            foreach (Fish fish in fishList)
            {
                fish.AddAge();
            }
            fishList = fishList.Where(fish => fish.Died == false).ToArray(); //remove from array all Died Fish
            algaList = algaList.Where(alga => alga.Died == false).ToArray();
        } //clear the arrays from dead fishes etc.
        public void PassTurn()
        {
            WriteLine("Turn " + turn);
            WriteLine("You've got " + algaList.Count() + " algas");
            WriteLine("You've got " + fishList.Count() + " fishes");
            ShowFish();
            InflictDamage();
            RemoveDead();
            turn++;
        }
    }
}
