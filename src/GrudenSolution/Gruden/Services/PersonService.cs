using Gruden.Data.Models;
using Gruden.Data.Repos;
using Microsoft.EntityFrameworkCore;

namespace Gruden.Services
{
    public class PersonService : IPersonService
    {
        private readonly ILogger<PersonService> _logger;
        private readonly IPersonRepository _personRepo;
        public PersonService(IPersonRepository personRepo, ILogger<PersonService> logger)
        {
            _personRepo = personRepo;
            _logger = logger;
        }

        public virtual async Task<Person> SetPersonAsync(Person person)
        {
            try
            {
                var retPerson = await _personRepo.SetPersonAsync(person);
                _logger.LogInformation($"Received request from {person.Name}");
                return retPerson;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }
    }
}
