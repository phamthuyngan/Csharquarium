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
        { }
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
