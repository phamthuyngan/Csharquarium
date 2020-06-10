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
        public Herbivore(string name, Genders gender, int age) : base(name, gender, age)
        {
            _specie = (HerbivoreSpecie)RNG.Next(0, Enum.GetNames(typeof(HerbivoreSpecie)).Length);
        }
        public override string Specie // get acces to specie read-only
        {
            get { return _specie.ToString(); }
        }
        public void Eat(Alga victim) // eat the alga
        {
            victim.GetDamage(2);
            this.GetHeal(3);
        }

        public void ChooseTarget(Alga[] victims)
        {
            Target = RNG.Next(0, victims.Length);//choose the target randomly
        }
    }
}
