using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class Tuna : Carnivore
    {
        public Tuna(string name) : base(name) { }
        public Tuna(string name, Genders gender) : base(name, gender) { }
        public Tuna(string newName, int newAge) : base(newName, newAge) { }
        public Tuna(string newName, Genders newGender, int age) : base(newName, newGender, age) { }
        public Tuna(string newName, int age, int pv, Genders newGender, bool wasAttacked, int target) : base(newName, age, pv, newGender, wasAttacked, target)
        { }
    }
}
 