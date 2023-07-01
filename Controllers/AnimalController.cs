using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Controllers
{
    public class AnimalController
    {

        private string directoryName = "ReportFiles";
        private string fileName = "Animals.txt";
        public List<Animal> List()
        {
            return DataSet.Animals;
        }

        public bool Insert(Animal animal)
        {
            if(animal==null)
                return false;

            if(animal.Id <= 0)
                return false;

            if(string.IsNullOrWhiteSpace(animal.Name))
                return false;

            DataSet.Animals.Add(animal);
            return true;
        }

        public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;
            foreach(Animal a in DataSet.Animals)
            {
                fileContent += $"{a.Id};{a.Name};{a.Race};{a.Birthdate}";
                fileContent +="\n";
            }

            try
            {
                StreamWriter sw = File.CreateText(
                $"{directoryName}\\{fileName}"
                );

                sw.Write(fileContent);
                sw.Close();
            }
            catch(IOException ioEx)
            {
                Console.WriteLine("Error handling the file.");
                Console.WriteLine(ioEx.Message);
                return false;
            }

            return true;
        }

        public bool ImportFromTxtFile()
        {
            try
            {
                StreamReader sr = new StreamReader(
                $"{directoryName}\\{fileName}"
                );

                string line = string.Empty;
                line = sr.ReadLine();
                while(line != null)
                {
                    Animal animal = new Animal();
                    string[] animalData = line.Split(';');
                    animal.Id = Convert.ToInt32(animalData[0]);
                    animal.Name = animalData[1];
                    animal.Race = animalData[2];
                    animal.Birthdate = animalData[3];

                    DataSet.Animals.Add(animal);

                    line = sr.ReadLine();
                }

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Oops, There was an error trying to import the data");
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<Animal> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrWhiteSpace(name) )
                return null;

            List<Animal> animals = new List<Animal>();
            for (int i = 0; i<DataSet.Animals.Count; i++)
            {
                var a = DataSet.Animals[i];
                if( a.Name.ToLower().Contains(name.ToLower()) )
                    animals.Add(a);
            }
            return animals;
        }

        public List<Animal> SearchByBirthdate(string birthdate)
        {
            if (string.IsNullOrEmpty(birthdate) ||
                string.IsNullOrWhiteSpace(birthdate) )
                return null;

            List<Animal> animals = new List<Animal>();
            for (int i = 0; i<DataSet.Animals.Count; i++)
            {
                var a = DataSet.Animals[i];
                if( a.Birthdate.ToLower().Contains(birthdate.ToLower()) )
                    animals.Add(a);
            }
            return animals;
        }

        public int GetNextId()
        {
            int count = DataSet.Animals.Count;

            Console.WriteLine("Quantity: " + count);

            if (count > 0)
                return DataSet.Animals[count - 1].Id + 1;
            else
                return 1;
        }
    }
}
