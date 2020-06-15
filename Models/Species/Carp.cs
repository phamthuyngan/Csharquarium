using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class Carp : Herbivore
    {
        public Carp(string name) : base(name) { }
        public Carp(string name, Genders gender) : base(name, gender) { }
        public Carp(string newName, int newAge) : base(newName, newAge) { }
        public Carp(string newName, Genders newGender, int age) : base(newName, newGender, age) { }
        public Carp(string newName, int age, int pv, Genders newGender, bool wasAttacked, int target) : base(newName, age, pv, newGender, wasAttacked, target)
        { }
    }
}
