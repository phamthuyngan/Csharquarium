using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class Sole : Herbivore, IOpportunist
    {
        public Sole(string name) : base(name) { }
        public Sole(string name, Genders gender) : base(name, gender) { }
        public Sole(string newName, int newAge) : base(newName, newAge) { }
        public Sole(string newName, Genders newGender, int age) : base(newName, newGender, age) { }
        public Sole(string newName, int age, int pv, Genders newGender, bool wasAttacked, int target) : base(newName, age, pv, newGender, wasAttacked, target)
        { }
    }
}
