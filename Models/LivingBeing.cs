using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    class LivingBeing //class parent of fishes and algas
    {
        protected static Random RNG = new Random(); // RNG for algas and fishes
        private int _age;
        private int _pv;
        public bool Died { get; private set; } //is it dead? Poke it with a stick

        public int PV
        {
            get { return _pv; }
            private set
            {
                if (value <= 0) // dead if not sufficient PV
                {
                    Died = true;
                    _pv = 0;
                }
                else
                {
                    _pv = value;
                }
            }
        }

        public int Age
        {
            get { return _age; }
            protected set
            {
                if (_age > 19) // dead if too old
                {
                    Died = true;
                    return;
                }
                _age = value;
            }
        }


        public LivingBeing()
        {
            Age = 0;
            PV = 10;
            Died = false;
        }
        public LivingBeing(int newAge, int newPV) : this()
        {
            Age = newAge;
            PV = newPV;
        }

        public void GetDamage(int damage)// receive damage
        {
            if (damage > 0)// can't inflict negative damage
            {
                PV -= damage;
            }
            else
            {
                throw new InvalidOperationException("Your value must be positive");
            }
        }
        public void GetHeal(int heal)//receive life point
        {
            if (heal > 0) // can't inflict negative heal point
            {
                PV += heal;
            }
            else
            {
                throw new InvalidOperationException("Your value must be positive");
            }
        }

        public virtual void AddAge() // get old
        { }
    }
}
