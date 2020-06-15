using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium.Models.Interfaces
{
    interface ISaveManager
    {
        void Save(string path, List<string> saveContent, string fileName);
        string[] Import(string path);
    }
}
