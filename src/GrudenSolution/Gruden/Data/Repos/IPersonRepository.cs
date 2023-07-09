using Gruden.Data.Models;

namespace Gruden.Data.Repos
{
    public interface IPersonRepository
    {
         Task<Person> SetPersonAsync(Person person);
    }
}
