
using System;
using System.Collections.Generic;
using System.IO;

namespace Csharquarium
{
    class SaveManager
    {
        FileManager fileManager;
        public SaveManager()
        {
            fileManager = new FileManager();
        }
        public void Save(string path, List<string> saveContent, string fileName)
        {
            fileManager.Save(path, saveContent, fileName); // écris dans le document toutes les strings dans saveInfos
        }
        public string[] Import(string path)
        {
            string[] importedData = fileManager.Import(path);
            if (importedData.Length < 3)
            {
                throw new InvalidDataException("The save file is corrupted or doesn't contain the right informations");
            }
            return importedData;
        }
    }
}
