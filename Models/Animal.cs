namespace Arquivos.Models
{
    public class Animal
    {
        public int Id {get;set;}
        public string? Name {get;set;}
        public string? Race {get;set;}
        public string? DateOfBirth {get;set;}

        public Animal()
        {

        }

        public override string ToString()
        {
            return $"Id: {this.Id}; Name: {this.Name}; Race: {this.Raca}; Date of birth: {this.DateOfBirth};";
        }
    }
}
