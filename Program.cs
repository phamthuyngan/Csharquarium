using Csharquarium.Models;
using System;
using System.Collections.Generic;

namespace Csharquarium
{
    class Program
    {
        public static Dictionary<string, SpeciesEnum> specieTranslation = new Dictionary<string, SpeciesEnum>
        {
            { "THON", SpeciesEnum.Tuna },
            {"CARPE", SpeciesEnum.Carp },
            {"BAR", SpeciesEnum.Bar },
            {"SOLE", SpeciesEnum.Sole },
            {"MÉROU", SpeciesEnum.Grouper },
            {"POISSON-CLOWN", SpeciesEnum.ClownFish }
        };
        static void Main(string[] args)
        {
            Game game = new Game();
            game.saveDefaultPath = @"C:\Users\ngan2\Documents\interface3\CS\OrienteObjet\Csharquarium\Aquarium.save";
            game.reportDefaultPath = @"C:\Users\ngan2\Documents\interface3\CS\OrienteObjet\Csharquarium\Aquarium_Report.save";

            string input = null;
            string path = null;
            string ageString = null;
            string ageFinal = null;

            for (int i = 0; i < 1; i++)
            {
                game.AddAlga();
            }
            game.AddFish("John Doe", Genders.Male);
            game.AddFish("Matrix", Genders.Female);
            game.AddFish("Truc", Genders.Female);
            game.AddFish("Machin", Genders.Male);
            game.AddFish("Macro", Genders.Male);
            //game.AddFish("Bar", Genders.Female);
            //game.AddFish("Narval", Genders.Male);
            //game.AddFish("Gupi", Genders.Female);
            //game.AddFish("Test");
            game.ShowGame();

            do
            {
                try
                {
                    input = Console.ReadLine();
                    switch (input.ToUpper())
                    {
                        case "SAVE":
                            game.renderer.Render("Please write the path of your save file and press ENTER or just press ENTER if you want to save to the default path");
                            path = Console.ReadLine();
                            if (path == "")
                            {
                                game.Save();
                            }
                            else
                            {
                                game.Save(path);
                            }

                            break;
                        case "LOAD":
                            game.renderer.Render("Please write the path of your save file and press ENTER or just press ENTER if you want to load from the default path");
                            path = Console.ReadLine();
                            if (path == "")
                            {
                                game.Load();
                            }
                            else
                            {
                                game.Load(path);
                            }
                            break;
                        case "":
                            game.PassTurn();
                            break;
                        default:
                            if (input.ToUpper().Contains("ALGUE") & input.ToUpper().Contains("AN") & input.ToUpper().IndexOf("ALGUE") < input.ToUpper().IndexOf("AN")) // if the user inputs algas to add
                            {
                                input = input.ToUpper().Trim(); // make the input all uppercase

                                string numberAlgaString = input.Substring(0, input.IndexOf("ALGUE")); // take all characters until the word "algue"
                                string numberOfAlgaFinal = null;

                                ageString = input.Substring(input.IndexOf("ALGUE") + 5, input.IndexOf("AN") - (numberAlgaString.Length + 5)); // take all characters between two words
                                ageFinal = null;

                                foreach (char element in numberAlgaString)
                                {
                                    if (Char.GetNumericValue(element) != -1)
                                    {
                                        numberOfAlgaFinal += element;
                                    }
                                }
                                foreach (char element in ageString) // get all numbers for the age
                                {
                                    if (Char.GetNumericValue(element) != -1)
                                    {
                                        ageFinal += element;
                                    }
                                }
                                if (int.TryParse(numberOfAlgaFinal, out int algasToAdd) & int.TryParse(ageFinal, out int ageOfAlga)) // check if the value is not null
                                {
                                    for (int i = 0; i < algasToAdd; i++)
                                    {
                                        game.AddAlga(ageOfAlga, 10); // add alga to the game
                                        game.renderer.Render("Alga(s) added, press ENTER to continue");
                                    }
                                }
                                else
                                {
                                    throw new InvalidOperationException("Your alga's parameters are not correctly encoded, please try again with better synthax");
                                    //game.renderer.Render("Your alga's parameters are not correctly encoded, please try again with better synthax");
                                }
                            }
                            else if (input.Contains(",") & input.ToUpper().Contains("AN"))
                            {
                                string[] parameters = input.Split(new char[] { ',' }); // split input in an array to make it easier to target

                                if (parameters.Length == 3 & parameters[2].ToUpper().Contains("AN"))
                                {
                                    parameters[0] = parameters[0].Trim();
                                    parameters[1] = parameters[1].ToUpper().Trim();
                                    parameters[2] = parameters[2].Substring(0, parameters[2].ToUpper().IndexOf("AN")).ToUpper(); // considers only the numbers before "an" to avoid a bug
                                    ageFinal = null;

                                    foreach (char element in parameters[2]) // make sure it keeps only the numbers from the substring
                                    {
                                        if (Char.GetNumericValue(element) != -1)
                                        {
                                            ageFinal += element;
                                        }
                                    }

                                    if (specieTranslation.ContainsKey(parameters[1]) & ageFinal != null) // check if the specie encoded is an existing specie and if the age is not null
                                    {
                                        game.AddFish(parameters[0], specieTranslation[parameters[1]], int.Parse(ageFinal.ToString())); // add the fish to the game
                                        game.renderer.Render("Fish added, press ENTER to continue");
                                    }
                                    else if (!specieTranslation.ContainsKey(parameters[1]))
                                    {
                                        throw new InvalidOperationException("The name of your fish's specie is spelled wrong. Please try again with a better spelling");
                                        //game.renderer.Render("The name of your fish's specie is spelled wrong. Please try again with a better spelling");
                                    }
                                    else if (ageFinal == null)
                                    {
                                        throw new InvalidOperationException("The age of your fish is not correctly encoded. Please try again with a better spelling");
                                        //game.renderer.Render("The age of your fish is not correctly encoded. Please try again with a better spelling");
                                    }
                                }
                                else
                                {
                                    throw new InvalidOperationException("Your fish's parameters are not correctly encoded, please try again with better synthax");
                                    //game.renderer.Render("Your fish's parameters are not correctly encoded, please try again with better synthax");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("The input you wrote seems wrong. Please check the syntax and write it correctly");
                                //game.renderer.Render("The input you wrote seems wrong. Please check the syntax and write it correctly");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (input != "x");
        }
    }
}
