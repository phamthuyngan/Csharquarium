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
        private enum CarnivoreSpecie { Grouper, Tuna, ClownFish };
        private CarnivoreSpecie _specie;
        //private Fish _victim;

        //public Fish Victim
        //{
        //    get { return _victim; }
        //    private set { myVar = value; }
        //}
        public Carnivore(string name, Genders gender) : base(name, gender)
        {
            _specie = (CarnivoreSpecie)RNG.Next(0, Enum.GetNames(typeof(CarnivoreSpecie)).Length);
        }
        public override string Specie
        {
            get { return _specie.ToString(); }
        }

        public void Eat(Fish victim)
        {
            WriteLine(this.name + " ate " + victim.name);
            victim.GetDamage(4);
            GetHeal(5);
        }
        public void ChooseTarget(Fish[] victims)
        {
            do
            {
                Target = RNG.Next(0, victims.Length);
            } while (victims[Target] == this | Specie == victims[Target].Specie);
            WriteLine(this.name + " will eat " + victims[Target].name);
        }
    }
}
