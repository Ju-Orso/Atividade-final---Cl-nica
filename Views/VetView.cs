using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Views
{
    public class VetView
    {
        private VetController vetController;

        public VetView()
        {
            vetController = new VetController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("*************** \n
                               VETERINARIANS \n
                               *************** \n \n
                               1 - Inset veterinarian \n
                               2 - List veterinarians \n
                               3 - Export to txt \n
                               4 - Import veterinarians \n
                               5 - Search veterinarians \n
                               0 - Return \n
                               *************** \n \n");
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
                    Console.WriteLine("SEARCH \n
                                       *************** \n
                                       1 - Search vet by name. \n
                                       2 - Search veterinarian by CRMV.");
                    int typeSearch = Convert.ToInt32(Console.ReadLine() );
                    if(typeSearch == 1)
                        SearchByName();
                    if(typeSearch == 2)
                        SearchByCRMV();
                    if(typeSearch != 1 && typeSearch !=2)
                        Console.WriteLine("\n Invalid option. \n");
                break;

                case 0:
                break;

                default:
                    Console.WriteLine("Ops, Invalid option!");
                    this.Init();
                break;
            }
        }

        private void List()
        {
            List<Vet> list =
                vetController.List();

            for (int i=0; i <list.Count; i++)
            {
                Console.WriteLine( Print( list[i] ) );
            }
        }

        private string Print(Vet vet)
        {
            string retorno = "";
            retorno+= $"Id: {vet.Id} \n";
            retorno+= $"Nome: {vet.FullName}\n";
            retorno+= $"CPF: {vet.CPF}\n";
            retorno+= $"CRMV: {vet.CRMV}\n";
            retorno+= "-------------------------------------------\n";
            return retorno;
        }
        private void Insert()
        {
            Vet vet = new Vet();
            vet.Id = vetController.GetNextId();

            Console.WriteLine("Enter first name:");
            vet.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            vet.LastName = Console.ReadLine();

            Console.WriteLine("Enter CRMV:");
            vet.CRMV = Console.ReadLine();

            Console.WriteLine("Enter CPF:");
            vet.CPF = Console.ReadLine();

            bool retorno = vetController.Insert(vet);

            if (retorno)
                Console.WriteLine("Veterinarian inserted successfully!");
            else
                Console.WriteLine("Insert failed, check data!");
        }
        private void Export()
        {
            if(vetController.ExportToTextFile())
                Console.WriteLine("File generated successfully!");

            else
                Console.WriteLine("Ops! Failed to generate the file.");

        }

        private void Import()
        {
            if(vetController.ImportFromTxtFile())
                Console.WriteLine("File imported successfully!");
            else
                Console.WriteLine("Ops! File import failed.");
        }

         private void SearchByName()
        {
            Console.WriteLine ("Enter the veterinarian's name here.");
            string name = Console.ReadLine();

            int contactor = 0;
            foreach( Vet v in vetController.SearchByName(name))
            {
                Console.WriteLine(v.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\nData not found!\n");
        }
        private void SearchByCRMV()
        {
            Console.WriteLine ("Enter the vet's CRMV here.");
            string CRMV = Console.ReadLine();

            int contactor = 0;
            foreach( Vet v in vetController.SearchByCRMV(CRMV))
            {
                Console.WriteLine(v.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\nData not found!\n");
        }
    }
}
