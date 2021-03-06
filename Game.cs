﻿using Csharquarium.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharquarium
{
    class Game
    {

        public string saveDefaultPath;
        public Renderer renderer { get; private set; }

        private Aquarium scene;
        private int turns;
        private SaveManager saveManager;
        public Game()
        {
            turns = 0;
            scene = new Aquarium();
            saveManager = new SaveManager();
            renderer = new Renderer();
            saveDefaultPath = null;
        }

        public void ShowGame() // show the content
        {
            foreach (string action in scene.Report)
            {
                renderer.Render(action);
            }
            renderer.Render();
            renderer.Render("Turn " + turns);
            renderer.Render("You've got " + scene.AlgaList.Count() + " algas");
            renderer.Render("You've got " + scene.FishList.Count() + " fishes");
            foreach (Fish fish in scene.FishList) //show the stats of the fishes
            {
                //WriteLine(fish.name + " / " + fish.Gender + " / PV : " + fish.PV + " / Age : " + fish.Age + " / Specie : " + fish.GetType().ToString());
                renderer.Render(fish.name + " : " + fish.Gender);
            }
        }
        public void PassTurn()
        {
            turns++;
            scene.ExecuteActions(); // execute all behaviour in the aquium
            if (saveDefaultPath != null)
            {
                saveManager.Save(saveDefaultPath, scene.Report, "Aquarium_Report.save"); // save the actions made in the turn in another file
            }
            else
            {
                throw new MissingFieldException("The default path is not encoded");
            }
            ShowGame(); // make console show the game
        }
        public void AddAlga()
        {
            scene.AddAlga();
        }
        public void AddAlga(int age, int pv)
        {
            scene.AddAlga(age, pv);
        }
        public void AddFish()
        {
            scene.AddFish("Anonymous");
        }
        public void AddFish(string name)
        {
            scene.AddFish(name);
        }
        public void AddFish(string name, Genders gender)
        {
            scene.AddFish(name, gender);
        }
        public void AddFish(string name, SpeciesEnum specie, int age)
        {
            scene.AddFish(name, specie, age);
        }
        public void AddFish(string name, int age, int pv, Genders gender, string specie, bool wasAttacked, int target) // encode a fish with full parameters
        {
            scene.AddFish(name, age, pv, gender, specie, wasAttacked, target);
        }
        public void Save()
        {
            if (saveDefaultPath != null)
            {
                Save(saveDefaultPath);
            }
            else
            {
                throw new MissingFieldException("The default path is not encoded");
            }
        }
        public void Save(string savePath)
        {
            List<string> saveContent = new List<string>();
            saveContent.Add(turns.ToString()); // number of turns passed
            saveContent.Add(scene.FishList.Length.ToString()); // number of fishes in the aquarium
            foreach (Fish fish in scene.FishList)
            {
                saveContent.Add(fish.GetInfos()); // add  the infos of the fishes
            }
            saveContent.Add(scene.AlgaList.Length.ToString()); // number of algas in the aquarium
            foreach (Alga alga in scene.AlgaList)
            {
                saveContent.Add(alga.Age + "\n" + alga.PV);
            }
            saveManager.Save(savePath, saveContent, "Aquarium.save");
            renderer.Render("Save successfully saved");
        }
        public void Load()
        {
            if (saveDefaultPath != null)
            {
                Load(saveDefaultPath);
            }
            else
            {
                throw new MissingFieldException("The default path is not encoded");
            }
        }
        public void Load(string path)
        {
            string[] importedData = saveManager.Import(path);

            scene = new Aquarium(); // create a new aquarium

            int.TryParse(importedData[0], out turns); // new value of turns
            int.TryParse(importedData[1], out int numberOfFish); // get the number of fishes

            for (int i = 0; i < numberOfFish; i++)
            {
                int startIndex = (i * 7) + 2; // where to start to take parameters for fishes
                AddFish(
                    importedData[startIndex], //name
                    int.Parse(importedData[startIndex + 1]),// age
                    int.Parse(importedData[startIndex + 2]),//pv
                    (Genders)Enum.Parse(typeof(Genders), importedData[startIndex + 3]),//gender
                    importedData[startIndex + 4],//specie
                    bool.Parse(importedData[startIndex + 5]),//wasAttacked
                    int.Parse(importedData[startIndex + 6])//target
                    );
            }

            int numberOfAlgas = int.Parse(importedData[numberOfFish * 7 + 2]);

            for (int i = 0; i < numberOfAlgas; i++)
            {
                int startIndex = (i * 2) + 3 + (numberOfFish * 7); // where to start to take parameters for algas
                AddAlga(int.Parse(importedData[startIndex]), int.Parse(importedData[startIndex + 1]));// add new alga with age and pv
            }
            renderer.Render("Save successfully imported");
        }
    }
}

