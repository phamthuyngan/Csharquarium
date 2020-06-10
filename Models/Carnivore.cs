using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Csharquarium.Models
{
    class Carnivore : Fish
    {
        private enum CarnivoreSpecie { Grouper, Tuna, ClownFish }; // enum of the species possible
        private CarnivoreSpecie _specie;
        private bool targetExist;
        public Carnivore(string name, Genders gender) : base(name, gender)
        {
            _specie = (CarnivoreSpecie)RNG.Next(0, Enum.GetNames(typeof(CarnivoreSpecie)).Length);
        }
        public Carnivore(string name, Genders gender, int age) : base(name, gender, age)
        {
            _specie = (CarnivoreSpecie)RNG.Next(0, Enum.GetNames(typeof(CarnivoreSpecie)).Length);
        }
        public override string Specie //access to the specie read-only
        {
            get { return _specie.ToString(); }
        }

        public void Eat(Fish victim) //PV management when eating
        {
            if (targetExist) //if there is a possible target
            {
                WriteLine(this.name + " ate " + victim.name);
                victim.GetDamage(4);
                this.GetHeal(5);
            }
        }
        public void ChooseTarget(Fish[] victims) 
        {
            targetExist = Array.Exists(victims, fish => fish.Specie != this.Specie); // check if there is another specie existing in the aquarium
            if (targetExist == false)
            {
                Target = 0;
                return;
            }
            else
            {
                do
                {
                    Target = RNG.Next(0, victims.Length); // choose a random index
                } while (victims[Target] == this | Specie == victims[Target].Specie);// if the fish is not this and not the same specie
            }
        }
    }
}
