using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models
{
    class Alga : LivingBeing
    {
        public Alga() : base()
        { }
        public Alga(int newAge, int newPV) : base(newAge, newPV)
        {
        }
        public override void AddAge()
        {
            GetHeal(1);
            Age++;
        }
    }
}
