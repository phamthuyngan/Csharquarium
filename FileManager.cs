using Csharquarium.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Csharquarium
{
    class FileManager : IFileManager
    {
        public void Save(string path, List<string> saveContent, string fileName)
        {
            if (Directory.Exists(path))
            {
                File.WriteAllLines(path + fileName, saveContent); // écris dans le document toutes les strings dans saveInfos
            }
            else
            {
                throw new InvalidOperationException("The path specified doesn't exist");
            }
        }
        public string[] Import(string path)
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(path))
                {
                    string[] imported = new string[0];
                    imported = File.ReadAllLines(path); // récupère toutes les lines dans le fichier de save
                    return imported;
                }
                else
                {
                    throw new FileNotFoundException("Can't find the file");
                }
            }
            else
            {
                throw new InvalidOperationException("The path specified doesn't exist");
            }
        }
    }
}
