namespace Arquivos.Models
{
    public class Client
    {
        public int Id{ get;set;}
        public string? FirstName { get; set; }
        public string? LastName {get;set;}
        public string? CPF {get;set;}
        public string? Email {get;set;}

        public Client()
        {

        }
        public Client(int id,
                    string? firstName,
                    string? lastName,
                    string? cPF,
                    string? Email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            this.Email = Email;
        }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.FullName}; CPF: {this.CPF}; Email: {this.Email};";
        }
    }
}
