using Csharquarium.Models.Interfaces;
using Csharquarium.Models.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    enum Genders { Female, Male };
    enum SpeciesEnum { Grouper, Tuna, ClownFish, Sole, Bar, Carp };

    delegate void ReproduceFish(string name, Fish parent);
    class Fish : LivingBeing
    {
        public bool WasAttacked { get; private set; }
        public string name;
        public event ReproduceFish Reproduce;
        protected int Target { get; set; }
        protected bool _gender;

        public Fish(string newName) : base()
        {
            name = newName;
            Gender = (Genders)RNG.Next(0, 2); // random gender if not spacified
            Reproduce = null;
            WasAttacked = false;
        }
        public Fish(string newName, Genders newGender) : this(newName)
        {
            Gender = newGender;
            Reproduce = null;
        }
        public Fish(string newName, Genders newGender, int age) : base(age, 10) // construct the Fish if we input an age value
        {
            name = newName;
            Gender = newGender;
            Reproduce = null;
            WasAttacked = false;
        }
        public Genders Gender // random gender 
        {
            get
            {
                return (Genders)Convert.ToInt32(_gender);
            }
            protected set
            {
                _gender = Convert.ToBoolean((int)value);
            }
        }
        public override void AddAge() //get old
        {
            GetDamage(1);
            Age++;
            WasAttacked = false;
            if (this is IHermaphrodite & Age > 0  & Age % 10 == 0 ) // Hermaphrodite behaviour when switch the gender by age
            {
                _gender = !_gender;
                Console.WriteLine(this.name + " changed gender, it's now a " + Gender.ToString());
            }
        }

        protected virtual void Eat()//eat another LivinBeing
        { }
        public void Attack()//Choose the next thing to eat
        { }
        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);
            WasAttacked = true;
        }

        public void Mate(Fish[] list)
        {
            if (list.Length > 1 & WasAttacked == false & PV >= 5)
            {
                int MateIndex = RNG.Next(0, list.Length);
                if (list[MateIndex] != this & list[MateIndex].GetType() == this.GetType())
                {
                    if (this is IOpportunist & list[MateIndex].Gender == this.Gender)
                    {
                        _gender = !_gender;
                        Console.WriteLine(this.name + " is now an opportunist, it's now a " + Gender.ToString());
                    }
                    if (list[MateIndex].Gender != this.Gender)
                    {
                        Reproduce("Child", this);
                    }
                }
            }
        }
    }
}


