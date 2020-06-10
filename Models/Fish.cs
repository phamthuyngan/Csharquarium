using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    public enum Genders { Female, Male };
    class Fish : LivingBeing
    {
        public string name;
        private int _target;
        private bool _gender;
        
        public Fish(string newName, Genders newGender) : base()
        {
            name = newName;
            Gender = newGender;
        }
        public Fish(string newName, Genders newGender, int age) : base(age, 10) // construct the Fish if we input an age value
        { 
            name = newName;
            Gender = newGender;
        }
        public int Target // index of the target in the array
        {
            get { return _target; }
            protected set { _target = value; }
        }

        public virtual string Specie { get; set; } // eache fish has a specie
        public Genders Gender // random gender 
        {
            get
            {
                return (Genders)Convert.ToInt32(_gender);
            }
            private set
            {
                _gender = Convert.ToBoolean((int)value);
            }
        }

        public override void AddAge() //get old
        {
            GetDamage(1);
            Age++;
        }

        public void Eat()//eat another LivinBeing
        { }
        public void ChooseTarget()//Choose the next thing to eat
        { }
    }
}


