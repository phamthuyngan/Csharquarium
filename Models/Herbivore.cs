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
        public Herbivore(string name) : base(name)
        {
        }
        public Herbivore(string name, Genders gender) : base(name, gender)
        {
        }
        public Herbivore(string newName, Genders newGender, int age) : base(newName, newGender, age)
        {
        }
        protected void Eat(Alga victim) // eat the alga
        {
            victim.GetDamage(2); // inflicts damage to victim
            this.GetHeal(3); // gets PV from eating
        }

        public void Attack(Alga[] victims)
        {
            if (WasAttacked == false & PV < 5 & victims.Length > 0)
            {
                Target = RNG.Next(0, victims.Length);//choose the target randomly
                Eat(victims[Target]); // eat the alga
            }
        }
    }
}
