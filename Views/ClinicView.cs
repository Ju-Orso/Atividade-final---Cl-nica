using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Views
{
    public class ClinicView
    {
        private ClinicController clinicController;

        public ClinicView()
        {
            clinicController = new ClinicController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("*************** \n
                              CLINICS \n
                              *************** \n \n
                              1 - Insert clinic \n
                              2 - List clinics \n
                              3 - Export to txt \n
                              4 - Import clinics \n
                              5 - Search clinics \n
                              0 - Return \n
                              *************** \n");
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
                                       1 - Search clinic by name. \n
                                      2 - Search Clinic by address.");
                    int typeSearch = Convert.ToInt32(Console.ReadLine() );
                    if(typeSearch ==1)
                        SearchByName();
                    if(typeSearch == 2)
                        SearchByEndereco();
                    if(typeSearch != 1 && typeSearch !=2)
                        Console.WriteLine("\n Invalid option. \n");
                break;

                case 0:
                break;

                default:
                    Console.WriteLine("Ops, invalid option!");
                    this.Init();
                break;
            }
        }
        private void List()
        {
            List<Clinic> list =
                clinicController.List();

            for (int i=0; i <list.Count; i++)
            {
                Console.WriteLine( Print( list[i] ) );
            }
        }

        private string Print(Clinic clinic)
        {
            string retorno = "";
            retorno+= $"Id: {clinic.Id} \n";
            retorno+= $"Nome: {clinic.Name}\n";
	        retorno +=$"Endereço: {clinic.Address}\n";
	        retorno +=$"Telefone: {clinic.Phone}\n";
            retorno +=$"CNPJ: {clinic.CNPJ}\n";
            retorno+= "-------------------------------------------\n";
            return retorno;
        }
        private void Insert()
        {
            Clinic clinic = new Clinic();
            clinic.Id = clinicController.GetNextId();

            Console.WriteLine("Enter clinic name:");
            clinic.Name = Console.ReadLine();

            Console.WriteLine("Enter the CNPJ of the clinic:");
            clinic.CNPJ = Console.ReadLine();

            Console.WriteLine("Enter the phone:");
            clinic.Phone = Console.ReadLine();

            Console.WriteLine("Enter the address:");
            clinic.Address = Console.ReadLine();

            bool retorno = clinicController.Insert(clinic);

            if (retorno)
                Console.WriteLine("Clinic inserted successfully!");
            else
                Console.WriteLine("Insert failed, check data!");
        }
        private void Export()
        {
            if(clinicController.ExportToTextFile())
                Console.WriteLine("File generated successfully!");

            else
                Console.WriteLine("Ops! Failed to generate the file.");

        }

        private void Import()
        {
            if(clinicController.ImportFromTxtFile())
                Console.WriteLine("File imported successfully!");
            else
                Console.WriteLine("Oops! File import failed.");
        }

        private void SearchByName()
        {
            Console.WriteLine ("Search clinic by name. \n Enter the name here:");
            string name = Console.ReadLine();

            int contactor = 0;
            foreach( Clinic c in clinicController.SearchByName(name))
            {
                Console.WriteLine(c.ToString());
                contactor++;
            }
            if(contactor == 0)
                Console.WriteLine("\n Data not found! \n");
        }
         private void SearchByAddress()
        {
            Console.WriteLine ("Enter the Clinic Address here.");
            string Address = Console.ReadLine();

            int contactor = 0;
            foreach( Clinic c in clinicController.SearchByAddress(Address))
            {
                Console.WriteLine(c.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\n Data not found! \n");
        }

    }
}
