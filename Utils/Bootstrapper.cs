using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Utils
{
    public static class Bootstrapper
    {
        public static void ChargeClients()
        {
            DataSet.Clients.Add(
                new Client{
                    Id = 1,
                    FirstName = "Mittie",
                    LastName = " Barrett",
                    CPF = "884.733.789-54",
                    Email = ""
                }
            );
        }

        public static void ChargeAnimals()
        {
            DataSet.Animals.Add(
                new Animal{
                    Id = 1,
                    Name = "Justin",
                    Race = "Border collie",
                    DateOfBirth = "10-01-2015"
                }
            );
        }

        public static void ChargeVets()
        {
            DataSet.Vets.Add(
                new Vet{
                    Id = 1,
                    FirstName = "Edgar",
                    LastName = "Morales",
                    CPF = "32171838604",
	                CRMV = "5098141"
                }
            );
        }

        public static void ChargeClinicas()
        {
            DataSet.Clinics.Add(
                new Clinic{
                    Id = 1,
                    Name = "Animal Care",
                    CNPJ = "60.339.947/0001-53",
                    Phone = "(511) 311-3194",
	                Address = "1911 Kacka Lane"
                }
            );
        }
    }
}
