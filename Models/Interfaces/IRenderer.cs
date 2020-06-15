using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models.Interfaces
{
    interface IRenderer
    {
        void Render();
        void Render(string input);
        void Clear();
    }
}
