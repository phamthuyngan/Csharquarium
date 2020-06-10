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
        protected static Random RNG = new Random();

        public Aquarium()
        {
            turn = 0;
            fishList = new Fish[0];
            algaList = new Alga[0];
        }

        public void AddFish(string name, Genders gender)
        {
            Fish newFish;
            if (RNG.Next(0, 10) > 4 )
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
        public void AddAlga()
        {
            Alga newAlga = new Alga();
            List<Alga> newAlgaList = algaList.ToList();
            newAlgaList.Add(newAlga);
            algaList = newAlgaList.ToArray();
        }

        public void ShowFish()
        {
            foreach (Fish fish in fishList)
            {
                WriteLine(fish.name + " / " + fish.Gender + " / " + fish.GetType() + " / PV : " + fish.PV + " / Age : " + fish.Age + " / Specie : " + fish.Specie);
            }
        }
        public void ChooseTarget()
        {
            foreach (Fish fish in fishList)
            {
                if (fish is Herbivore herb)
                {
                    herb.ChooseTarget(algaList);
                }
                else if (fish is Carnivore carn)
                {
                    carn.ChooseTarget(fishList);
                }
                else
                {
                    WriteLine("This type of fish can't choose a target");
                }
            }
        }
        public void InflictDamage()
        {
            foreach (Fish fish in fishList)
            {
                if (fish is Carnivore carn)
                {
                    if (fishList.Length == 1)
                    {
                        WriteLine(fishList[0].name + " died hungry");
                        WriteLine("Your aquarium died");
                        fishList[0] = null;
                    }
                    else if (fishList.Length > 0 && fishList[carn.Target] != null)
                    {
                        carn.Eat(fishList[carn.Target]);
                        if (fishList[carn.Target].Died)
                        {
                            fishList[carn.Target] = null;
                        }
                    }
                }
                else if (fish is Herbivore herb)
                {
                    if (algaList.Length > 0 && algaList[fish.Target] != null)
                    {
                        herb.Eat(algaList[fish.Target]);
                        if (algaList[fish.Target].Died)
                        {
                            algaList[fish.Target] = null;
                        }
                    }
                }

            }
            fishList = fishList.Where(fish => fish != null).ToArray();//Removes all null from array
            algaList = algaList.Where(alga => alga != null).ToArray();
        }
        public void AddAge()
        {
            foreach (Alga alga in algaList)
            {
                alga.AddAge();
            }
            foreach (Fish fish in fishList)
            {
                fish.AddAge();
            }
        }
        public void PassTurn()
        {
            turn++;
            WriteLine("Turn " + turn);
            WriteLine("You've got " + algaList.Count() + " algas");
            WriteLine("You've got " + fishList.Count() + " fishes");
            ShowFish();
            ChooseTarget();
            //InflictDamage();
            AddAge();
        }
    }
}
