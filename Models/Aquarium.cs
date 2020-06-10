using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Csharquarium.Models
{
    class Aquarium
    {
        public Fish[] FishList { get; private set; }
        public Alga[] AlgaList { get; private set; }
        protected static Random RNG = new Random();// RNG for the aquarium

        public Aquarium()
        {
            FishList = new Fish[0];
            AlgaList = new Alga[0];
        }

        public void AddFish(string name, Genders gender) // add fishes to the aquarium
        {
            SpeciesEnum randomSpecie = (SpeciesEnum)RNG.Next(0, Enum.GetNames(typeof(SpeciesEnum)).Length);
            Type type = Type.GetType("Csharquarium.Models.Species." + randomSpecie.ToString());
            Fish newFish = (Fish)Activator.CreateInstance(type, name, gender);
            AddToArray(newFish);
        }
        public void AddFish(string name) // add fishes to the aquarium
        {
            SpeciesEnum randomSpecie = (SpeciesEnum)RNG.Next(0, Enum.GetNames(typeof(SpeciesEnum)).Length);
            Type type = Type.GetType("Csharquarium.Models.Species." + randomSpecie.ToString());
            Fish newFish = (Fish)Activator.CreateInstance(type, name);
            AddToArray(newFish);
        }
        public void AddAlga() //Add algas to the aquarium
        {
            Alga newAlga = new Alga();
            AddToArray(newAlga);
        }
        public void AddAlga(int newAge, int newPV) //Add algas to the aquarium
        {
            Alga newAlga = new Alga(newAge, newPV);
            AddToArray(newAlga);
        }
        private void AddToArray(LivingBeing newElement) // add nes element to the right array
        {
            newElement.death += RemoveDead;
            if (newElement is Fish fish)
            {
                List<Fish> newFishList = FishList.ToList();
                newFishList.Add(fish);
                FishList = newFishList.ToArray();
            }
            else if (newElement is Alga alga)
            {
                List<Alga> newAlgaList = AlgaList.ToList();
                newAlgaList.Add(alga);
                AlgaList = newAlgaList.ToArray();
            }
        }
        public void GiveBirth(string name, Fish parent)
        {
            Type type = parent.GetType();
            Fish newFish = (Fish)Activator.CreateInstance(type, name);

            List<Fish> newFishList = FishList.ToList();
            newFishList.Add(newFish);
            FishList = newFishList.ToArray();
        }
        private void LivingBehaviour() //choose target from array
        {
            foreach (Fish fish in FishList)
            {
                if (fish.PV < 5)
                {
                    if (fish is Herbivore herb)
                    {
                        if (AlgaList.Length > 0)
                        {
                            herb.ChooseTarget(AlgaList);
                            herb.Eat(AlgaList[fish.Target]);
                        }
                    }
                    else if (fish is Carnivore carn)
                    {
                        carn.ChooseTarget(FishList);
                        carn.Eat(FishList[carn.Target]);
                    }
                }
                else if (fish.PV >= 5 & fish.ChooseMate(FishList)) // give birth to a new fish 
                {
                    GiveBirth("Child", fish);
                }
            }
            foreach (Alga alga in AlgaList)
            {
                if (alga.PV >= 10)
                {
                    AddAlga(0, 5);
                    alga.GetDamage(5);
                }
            }
        }
        private void RemoveDead(LivingBeing dead)
        {
            if (dead is Fish)
            {
                FishList = FishList.Where(fish => fish != dead).ToArray(); //remove from array all Died Fish
            }
            else if (dead is Alga)
            {
                AlgaList = AlgaList.Where(alga => alga != dead).ToArray();
            }
            WriteLine(dead.ToString() + " died");
        }
        private void AddAge()
        {
            foreach (Alga alga in AlgaList) //add the age of the fish
            {
                alga.AddAge();
            }
            foreach (Fish fish in FishList)
            {
                fish.AddAge();
            }
        }
        public void ExecuteActions()
        {
            LivingBehaviour();
            AddAge();
        }
    }
}
