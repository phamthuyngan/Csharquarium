using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Csharquarium.Models
{
    class Herbivore : Fish
    {
        private enum HerbivoreSpecie { Sole, Bar, Carp };
        private HerbivoreSpecie _specie;

        public Herbivore(string name, Genders gender) : base(name, gender)
        {
            _specie = (HerbivoreSpecie)RNG.Next(0, Enum.GetNames(typeof(HerbivoreSpecie)).Length);
        }
        public override string Specie
        {
            get { return _specie.ToString(); }
        }
        public void Eat(Alga victim)
        {
            victim.GetDamage(2);
            GetHeal(3);
        }

        public void ChooseTarget(Alga[] victims)
        {
            Target = RNG.Next(0, victims.Length);
            WriteLine(this.name + " will eat alga number " + Target);
        }
    }
}
