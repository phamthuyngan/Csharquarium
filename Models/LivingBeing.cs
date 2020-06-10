using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    class LivingBeing
    {
        protected static Random RNG = new Random();
        private int _age;
        private int _pv;
        public bool Died { get; private set; }

        public int PV
        {
            get { return _pv; }
            private set
            {
                if (value <= 0)
                {
                    Died = true;
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
                if (_age > 20)
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

        public void GetDamage(int damage)
        {
            PV -= damage;
        }
        public void GetHeal(int heal)
        {
            if (heal > 0)
            {
                PV += heal;
            }
            else
            {
                throw new InvalidOperationException("Your value must be positive");
            }
        }

        public virtual void AddAge()
        { }
    }
}
