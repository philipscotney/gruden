using System.ComponentModel.DataAnnotations.Schema;

namespace Gruden.Data.Models;

public class Person
{
    public Person() { }
        
    public int Id { get; set; }
    public string? Name { get; set; }
}
