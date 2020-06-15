using Csharquarium.Models.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Csharquarium.Models
{
    delegate void DelegateAlga(Alga[] victims);
    delegate void DelegateFish(Fish[] victims);
    delegate void DelegateReproduceAlga();
    delegate void DelegateReport(string lineToAdd);
    class Aquarium
    {
        public Fish[] FishList { get; private set; }
        public Alga[] AlgaList { get; private set; }
        public List<string> Report { get; private set; }

        private static Random RNG = new Random();// RNG for the aquarium
        private event DelegateAlga AttackHerb;
        private event DelegateReproduceAlga ReproduceAlga;
        private event DelegateFish AttackCarn;
        private event DelegateFish ReproduceFish;

        public Aquarium()
        {
            FishList = new Fish[0];
            AlgaList = new Alga[0];
            AttackHerb = null;
            AttackCarn = null;
            ReproduceFish = null;
            ReproduceAlga = null;
            Report = new List<string>();
        }

        public void AddFish(string name) // add fishes to the aquarium
        {
            SpeciesEnum randomSpecie = (SpeciesEnum)RNG.Next(0, Enum.GetNames(typeof(SpeciesEnum)).Length);
            Type type = Type.GetType("Csharquarium.Models.Species." + randomSpecie.ToString());
            Fish newFish = (Fish)Activator.CreateInstance(type, name);
            AddToArray(newFish);
        }
        public void AddFish(string name, Genders gender) // add fishes to the aquarium
        {
            SpeciesEnum randomSpecie = (SpeciesEnum)RNG.Next(0, Enum.GetNames(typeof(SpeciesEnum)).Length);
            Type type = Type.GetType("Csharquarium.Models.Species." + randomSpecie.ToString());
            Fish newFish = (Fish)Activator.CreateInstance(type, name, gender);
            AddToArray(newFish);
        }
        public void AddFish(string name, SpeciesEnum specie, int age) // adding the fish by the console
        {
            Type type = Type.GetType("Csharquarium.Models.Species." + specie.ToString());
            Fish newFish = (Fish)Activator.CreateInstance(type, name, age);
            AddToArray(newFish);
        }
        public void AddFish(string name, int age, int pv, Genders gender, string specie, bool wasAttacked, int target) // constructor with full parameters
        {
            Type type = Type.GetType(specie);
            Fish newFish = (Fish)Activator.CreateInstance(type, name, age, pv, gender, wasAttacked, target);
            AddToArray(newFish);
        }
        public void AddAlga() //add algas to the aquarium
        {
            Alga newAlga = new Alga();
            AddToArray(newAlga);
        }
        public void AddAlga(int newAge, int newPV) //Add algas to the aquarium
        {
            Alga newAlga = new Alga(newAge, newPV);
            AddToArray(newAlga);
        }
        private void AddToArray(LivingBeing newElement) // add new element to the right array
        {
            newElement.ReportToAqua += AddToReport;
            if (newElement is Fish fish)
            {
                List<Fish> newFishList = FishList.ToList(); // add fish to array
                newFishList.Add(fish);
                FishList = newFishList.ToArray();

                fish.Reproduce += delegate (string name, Fish parent) // link the reproduction actionby an anonymous delegate to the fish delegate 
                {
                    Fish newFish = (Fish)Activator.CreateInstance(parent.GetType(), name);
                    AddToArray(newFish);
                };
                ReproduceFish += fish.Mate; // add the mating action to the reproduction general delegate

                if (fish is Carnivore carn) // add the attacking action to the attacking general delegate
                {
                    AttackCarn += carn.Attack;
                }
                else if (fish is Herbivore herb)
                {
                    AttackHerb += herb.Attack;
                }
            }
            else if (newElement is Alga alga) // Add the alga to the array
            {
                List<Alga> newAlgaList = AlgaList.ToList();
                newAlgaList.Add(alga);
                AlgaList = newAlgaList.ToArray();

                alga.Reproduce += AddAlga; // add the reproduction action to the alga delegate
                ReproduceAlga += alga.Grow; // add the alga's reproduction action to the general delegate
            }
            newElement.death += RemoveDead; // Link the function that removes the element when it dies to the element's delegate
        }

        private void LivingBehaviour() //choose target from array
        {
            if (AlgaList.Length > 0) // if there is some alga
            {
                if (AttackHerb != null)
                {
                    AttackHerb(AlgaList); // make herbivore eat
                }
                if (ReproduceAlga != null)
                {
                    ReproduceAlga(); // alga multiplying
                }
            }
            if (FishList.Length > 1) // if there is several fishes
            {
                AttackCarn(FishList); // make carnivores attack
                ReproduceFish(FishList);// fish multiplying
            }
        }

        private void RemoveDead(LivingBeing dead) // removing an element from the scene
        {
            if (dead is Fish fish)
            {
                FishList = FishList.Where(diedFish => diedFish != dead).ToArray(); //remove from array all died Fish

                if (fish is Carnivore carn)// remove from general delegate the action so it's not triggered anymore
                {
                    AttackCarn -= carn.Attack; 
                }
                else if (fish is Herbivore herb)
                {
                    AttackHerb -= herb.Attack;
                }
                ReproduceFish -= fish.Mate;

                AddToReport(fish.name.ToString() + " died");
            }
            else if (dead is Alga alga)
            {
                AlgaList = AlgaList.Where(diedAlga => diedAlga != dead).ToArray(); // remove from array all died algas
                ReproduceAlga -= alga.Grow; // remove from general delegate the growing action

                AddToReport("An alga disapeared");
            }
            dead.Dispose(); // make the object disposable for garbage collector
        }
        private void AddAge() // make objects get older
        {
            foreach (Alga alga in AlgaList)
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
            //Report = new List<string>();
            LivingBehaviour();
            AddAge();
        }

        public void AddToReport(string lineToAdd) // Add action to the report
        { Report.Add(lineToAdd); }
    }
}
