using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    delegate void Death(LivingBeing dead);
    class LivingBeing //class parent of fishes and algas
    {
        protected static Random RNG = new Random(); // RNG for algas and fishes
        private int _age;
        private int _pv;
        public event Death death;

        public int PV
        {
            get { return _pv; }
            private set
            {
                if (value <= 0) // dead if not sufficient PV
                {
                    _pv = 0;
                    death(this); // call the function that remove from list
                    return;
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
                if (_age > 19)
                {
                    death(this); // call the function that remove from list
                    return;
                }
                _age = value;
            }
        }


        public LivingBeing()
        {
            Age = 0;
            PV = 10;
            death = null;
        }
        public LivingBeing(int newAge, int newPV)
        {
            Age = newAge;
            PV = newPV;
            death = null;
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
