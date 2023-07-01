using System;
using System.Collections.Generic;
using System.IO;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Controllers
{
    public class ClinicController
    {
        private string directoryName = "ReportFiles";
        private string fileName = "Clinics.txt";

        public List<Clinic> List()
        {
            return DataSet.Clinics;
        }

        public bool Insert(Clinic clinic)
        {
            if(clinic == null)
                return false;

            if (clinic.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(clinic.Name))
                return false;

            DataSet.Clinics.Add(clinic);
            return true;
        }

        public bool ExportToTextFile()
        {
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            string fileContent = string.Empty;
            foreach(Clinic c in DataSet.Clinics)
            {
                fileContent += $"{c.Id};{c.Name};{c.CNPJ};{c.Address};{c.Phone}";
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
                Console.WriteLine("Error while manipulating the file.");
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
                    Clinic clinic = new Clinic();
                    string[] clinicData = line.Split(';');
                    clinic.Id = Convert.ToInt32(clinicData[0]);
                    clinic.Name = clinicData[1];
                    clinic.CNPJ = clinicData[2];
                    clinic.Address = clinicData[3];
                    clinic.Phone = clinicData[4];

                    DataSet.Clinics.Add(clinic);

                    line = sr.ReadLine();
                }

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Oops, an error occurred while trying to import the data.");
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<Clinic> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrWhiteSpace(name) )
                return null;

            List<Clinic> clinics = new List<Clinic>();
            for (int i = 0; i < DataSet.Clinics.Count; i++)
            {
                var c = DataSet.Clinics[i];
                if( c.Name.ToLower().Contains(name.ToLower()) )
                    clinics.Add(c);
            }
            return clinics;
        }

        public List<Clinic> SearchByAddress(string address)
        {
            if (string.IsNullOrEmpty(address) ||
                string.IsNullOrWhiteSpace(address) )
                return null;

            List<Clinic> clinics = new List<Clinic>();
            for (int i = 0; i < DataSet.Clinics.Count; i++)
            {
                var c = DataSet.Clinics[i];
                if( c.Address.ToLower().Contains(address.ToLower()) )
                    clinics.Add(c);
            }
            return clinics;
        }

        public int GetNextId()
        {
            int count = DataSet.Clinics.Count;

            Console.WriteLine("Quantity: " + count);

            if (count > 0)
                return DataSet.Clinics[count - 1].Id + 1;
            else
                return 1;
        }
    }
}
