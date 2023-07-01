using Arquivos.Controllers;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Views
{
    public class ClientView
    {
        private ClientController clientController;

        public ClientView()
        {
            clientController = new ClientController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("*************** \n
                              CLIENTS \n
                              *************** \n \n
                              1 - Insert client \n
                              2 - List clients \n
                              3 - Export to txt \n
                              4 - Import clients \n
                              5 - Search clients \n
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
                                       1 - Search customer by name. \n
                                       2 - Pesquisar cliente por CPF.");
                    int typeSearch = Convert.ToInt32(Console.ReadLine() );
                    if(typeSearch ==1)
                        SearchByName();
                    if(typeSearch == 2)
                        SearchByCPF();
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
            List<Client> lsit =
                clientController.List();

            for (int i=0; i <lsit.Count; i++)
            {
                Console.WriteLine( Print( lsit[i] ) );
            }
        }

        private string Print(Client client)
        {
            string retorno = "";
            retorno+= $"Id: {client.Id} \n";
            retorno+= $"Nome: {client.FullName}\n";
            retorno+= $"CPF: {client.CPF}\n";
            retorno+= $"E-mail: {client.Email}\n";
            retorno+= "-------------------------------------------\n";
            return retorno;
        }
        private void Insert()
        {
            Client client = new Client();
            client.Id = clientController.GetNextId();

            Console.WriteLine("Enter first name:");
            client.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            client.LastName = Console.ReadLine();

            Console.WriteLine("Enter the email:");
            client.Email = Console.ReadLine();

            Console.WriteLine("Enter the CPF:");
            client.CPF = Console.ReadLine();

            bool retorno = clientController.Insert(client);

            if (retorno)
                Console.WriteLine("Customer inserted successfully!");
            else
                Console.WriteLine("Insert failed, check data!");
        }
        private void Export()
        {
            if(clientController.ExportToTextFile())
                Console.WriteLine("File generated successfully!");

            else
                Console.WriteLine("Oops! Failed to generate the file.");

        }

        private void Import()
        {
            if(clientController.ImportFromTxtFile())
                Console.WriteLine("File imported successfully!");
            else
                Console.WriteLine("Oops! File import failed.");
        }

        private void SearchByName()
        {
            Console.WriteLine ("Enter the customer's name here.");
            string name = Console.ReadLine();

            int contactor = 0;
            foreach( Client c in clientController.SearchByName(name))
            {
                Console.WriteLine(c.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\n Data not found! \n");
        }
        private void SearchByCPF()
        {
            Console.WriteLine ("Enter the customer's CPF here.");
            string CPF = Console.ReadLine();

            int contactor = 0;
            foreach( Client c in clientController.SearchByCPF(CPF))
            {
                Console.WriteLine(c.ToString());
                contactor ++;
            }
            if(contactor == 0)
                Console.WriteLine("\n Data not found! \n");
        }
    }
}
