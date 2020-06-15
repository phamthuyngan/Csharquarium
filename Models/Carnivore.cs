using System;
using System.Collections.Generic;

namespace Csharquarium.Models
{
    class Carnivore : Fish
    {
        private bool targetExist;
        public Carnivore(string name) : base(name)
        {
        }
        public Carnivore(string name, Genders gender) : base(name, gender)
        { }
        public Carnivore(string newName, int newAge) : base(newName, newAge) { }
        public Carnivore(string newName, Genders newGender, int age) : base(newName, newGender, age)
        { }
        public Carnivore(string newName, int age, int pv, Genders newGender, bool wasAttacked, int target) : base(newName, age, pv, newGender, wasAttacked, target)
        { }

        protected void Eat(Fish victim) //PV management when eating
        {
            ReportToAqua(this.name + " bite " + victim.name);
            victim.GetDamage(4);
            this.GetHeal(5);
        }
        public void Attack(Fish[] victims)
        {
            targetExist = Array.Exists(victims, fish => fish.GetType() != this.GetType()); // check if there is another specie existing in the aquarium
            if (targetExist & !WasAttacked & PV < 5)
            {
                do
                {
                    Target = RNG.Next(0, victims.Length); // choose a random index
                } while (victims[Target] == this | this.GetType() == victims[Target].GetType());// if the fish is not this and not the same specie
                Eat(victims[Target]); //Attack the target
            }
            else
            {
                return;
            }
        }
    }
}
