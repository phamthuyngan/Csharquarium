using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    class Renderer
    {
        public void Render(string input)
        {
            Console.WriteLine(input);
        }
        public void Render()
        { Console.WriteLine(); }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
