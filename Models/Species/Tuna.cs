using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharquarium.Models.Interfaces;

namespace Csharquarium.Models.Species
{
    class Tuna : Carnivore, IMonosex
    {
        public Tuna(string name) : base(name) { }
        public Tuna(string name, Genders gender) : base(name, gender) { }
        public Tuna(string newName, Genders newGender, int age) : base(newName, newGender, age) { }
    }
}
 