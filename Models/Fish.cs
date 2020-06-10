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
        public int Target
        {
            get { return _target; }
            protected set { _target = value; }
        }

        public virtual string Specie { get; set; }
        public Genders Gender
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

        public override void AddAge()
        {
            GetDamage(1);
            Age++;
        }

        public void Eat()
        { }
        public void ChooseTarget()
        { }
    }
}


