using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquivos.Models
{
    public class Clinic
    {
        public int Id{ get;set;}
        public string? Name {get;set;}
        public string? Address {get;set;}
        public string? CNPJ { get;set;}
        public string? Phone { get;set;}

        public Clinic()
        {

        }

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.Name}; Address: {this.Address}; CNPJ: {this.CNPJ}; Phone: {this.Phone}";
        }

    }
}
