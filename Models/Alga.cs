using System;
using System.Collections.Generic;

namespace Csharquarium.Models
{
    delegate void ReproduceAlga(int age, int pv);
    class Alga : LivingBeing
    {
        public event ReproduceAlga Reproduce;
        public Alga() : base()
        { Reproduce = null; }
        public Alga(int newAge, int newPV) : base(newAge, newPV)
        {
            Reproduce = null;
        }
        public override void AddAge()
        {
            GetHeal(1);
            Age++;
            //ReportToAqua("Alga gets older");
        }

        public void Grow()
        {
            if (PV >= 10 & Reproduce != null)
            {
                Reproduce(0, 5); // Create a new alga with 0 age and 5 PV
                GetDamage(5);
                ReportToAqua("Alga reproduced");
            }
        }
    }
}
