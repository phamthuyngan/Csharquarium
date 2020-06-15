using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class Bar : Herbivore, IHermaphrodite
    {
        public Bar(string name) : base(name) { }
        public Bar(string name, Genders gender) : base(name, gender) { }
        public Bar(string newName, int newAge) : base(newName, newAge) {}
        public Bar(string newName, Genders newGender, int age) : base(newName, newGender, age) { }

        public Bar(string newName, int age, int pv, Genders newGender, bool wasAttacked, int target) : base(newName, age, pv, newGender, wasAttacked, target)
        { }
    }
}
