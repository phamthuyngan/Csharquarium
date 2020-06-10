using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class ClownFish : Carnivore, IOpportunist
    {
        public ClownFish(string name) : base(name) { }
        public ClownFish(string name, Genders gender) : base(name, gender) { }
        public ClownFish(string newName, Genders newGender, int age) : base(newName, newGender, age) { }
    }
}
