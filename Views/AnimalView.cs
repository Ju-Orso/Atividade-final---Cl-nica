using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Views
{
    public class AnimalView
    {
        private AnimalController animalController;

        public AnimalView()
        {
            animalController = new AnimalController();
            this.Init();
        }

        public void Init()
        {
            Console.WriteLine("***************** \n
                               ANIMALS \n
                               ***************** \n \n
                               1 - Insert animal \n
                               2 - List animals \n
                               3 - Export to txt \n
                               4 - Import animals \n
                               5 - Search animals \n
                               0 - Return \n
                               ***************** \n");
            int option = 0;
            option = Convert.ToInt32(Console.ReadLine() );
            switch(option){
                case 1 :
                    Insert();
                break;
                case 2 :
                    List();
                break;
                case 3:
                    Export();
                break;
                case 4:
                    Import();
                break;
                case 5:
                    Console.WriteLine("SEARCH \r\n
                                       *************** \r\n
                                       1 - Search animal by name. \r\n
                                       2 - Search animal by Date of Birth.");
                    int typeSearch = Convert.ToInt32(Console.ReadLine() );
                    if(typeSearch ==1)
                        SearchByName();
                    if(typeSearch == 2)
                        SearchByDateOfBirth();
                    if(typeSearch != 1 && typeSearch !=2)
                        Console.WriteLine("\r\n Invalid option. \r\n");
                break;
                case 0:
                break;
                default:
                    Console.WriteLine("\n Oops, invalid option! \n");
                    this.Init();
                break;
            }
        }

        private void List()
        {
            List<Animal> list = animalController.List();

            for (int i=0; i<list.Count; i++)
            {
                Console.WriteLine (Print(list[i]));
            }
        }

        private string Print (Animal animal)
        {
            string retorno = "";
            retorno+= $"Id: {animal.Id} \n";
            retorno+= $"Name: {animal.Name} \n";
            retorno+= $"Race: {animal.Race} \n";
            retorno+= $"Date of Birth: {animal.DateOfBirth}\n";
            retorno+= "-------------------------------------------\n";
            return retorno;
        }

        private void Insert()
        {
            Animal animal = new Animal();
            animal.Id = animalController.GetNextId();

            Console.WriteLine("Enter the name of the animal:");
            animal.Name = Console.ReadLine();

            Console.WriteLine("Enter the race:");
            animal.Raca = Console.ReadLine();

            Console.WriteLine("Inform the birth of the animal:");
            animal.DateOfBirth = Console.ReadLine();

            bool retorno = animalController.Insert(animal);

            if (retorno)
                Console.WriteLine("Animal inserted successfully!");
            else
                Console.WriteLine("Insert failed, check data!");
        }

        private void Export()
        {
            if (animalController.ExportToTextFile())
                Console.WriteLine("File generated successfully!");

            else
                Console.WriteLine("Ooops! Failed to generate the file.");
        }
        private void Import()
        {
            if (animalController.ImportFromTxtFile())
                Console.WriteLine("File imported successfully!");

            else
                Console.WriteLine("Ooops! File import failed.");
        }

        private void SearchByName()
        {
            Console.WriteLine ("Search animal by name. \n Enter the name here:");
            string name = Console.ReadLine();

            int contactor = 0;
            foreach( Animal a in animalController.SearchByName(name))
            {
                Console.WriteLine(a.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\n Data not found! \n");
        }
        private void SearchByDateOfBirth()
        {
            Console.WriteLine ("Enter the animal's date of birth here.");
            string DateOfBirth = Console.ReadLine();

            int contactor = 0;
            foreach( Animal a in animalController.SearchByDateOfBirth(DateOfBirth))
            {
                Console.WriteLine(a.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\n Data not found! \n");
        }
    }
}
