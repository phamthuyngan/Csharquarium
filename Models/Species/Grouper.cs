using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class Grouper : Carnivore, IHermaphrodite
    {
        public Grouper(string name) : base(name) { }
        public Grouper(string name, Genders gender) : base(name, gender) { }
        public Grouper(string newName, int newAge) : base(newName, newAge) { }
        public Grouper(string newName, Genders newGender, int age) : base(newName, newGender, age) { }
        public Grouper(string newName, int age, int pv, Genders newGender, bool wasAttacked, int target) : base(newName, age, pv, newGender, wasAttacked, target)
        { }
    }
}
