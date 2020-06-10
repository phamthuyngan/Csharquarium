using Csharquarium.Models.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    public enum Genders { Female, Male };
    public enum SpeciesEnum { Grouper, Tuna, ClownFish, Sole, Bar, Carp };
    class Fish : LivingBeing
    {
        //public static Dictionary<string, Type> specieDico = new Dictionary<string, Type>
        //    { 
        //    { "Grouper", typeof(Grouper)}
        //};
        public string name;
        private int _target;
        private bool _gender;
        public int MateIndex { get; protected set; }

        public Fish(string newName) : base()
        {
            name = newName;
            Gender = (Genders)RNG.Next(0, 2);
        }
        public Fish(string newName, Genders newGender) : this(newName)
        {
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

        //public SpeciesEnum Specie // eache fish has a specie
        //{
        //    get
        //    {
        //        return (SpeciesEnum)Enum.Parse(typeof(SpeciesEnum), this.GetType().ToString());
        //    }
        //}
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
        }

        public void Eat()//eat another LivinBeing
        { }
        public void ChooseTarget()//Choose the next thing to eat
        { }

        public bool ChooseMate(Fish[] list)
        {
            if (list.Length > 1)
            {
                MateIndex = RNG.Next(0, list.Length);
                if (list[MateIndex] != this & list[MateIndex].GetType() == this.GetType() & list[MateIndex].Gender != this.Gender)
                {
                    return true;
                }
            }
            return false;
        }
    }
}


