using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    class FileManager
    {

        public void Save(string path, List<string> saveContent)
        {
            File.WriteAllLines(path, saveContent); // écris dans le document toutes les strings dans saveInfos
        }
        public string[] Import(string path)
        {
            if (File.Exists(path))
            {
                string[] imported = new string[0];
                imported = File.ReadAllLines(path); // récupère toutes les lines dans le fichier de save
                return imported;
            }
            else
            {
                return null;
            }
        }
    }
}
