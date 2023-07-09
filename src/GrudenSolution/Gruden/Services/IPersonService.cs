using Gruden.Data.Models;

namespace Gruden.Services
{
    public interface IPersonService
    {
        Task<Person> SetPersonAsync(Person person);
    }
}