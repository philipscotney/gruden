using Microsoft.EntityFrameworkCore;
using System;
using Gruden.Data;
using Gruden.Data.Models;

namespace Gruden.Data.Repos;

public class PersonRepository : IPersonRepository
{
    private readonly IDbContextFactory<PersonDbContext> _personDbContextFactory;
    public PersonRepository(IDbContextFactory<PersonDbContext> personDbContextFactory)
    {
        _personDbContextFactory = personDbContextFactory;
    }

    public async Task<Person> SetPersonAsync(Person person)
    {
        using var db = _personDbContextFactory.CreateDbContext();

        db.Persons.Update(person);

        await db.SaveChangesAsync();

        return person;
    }
}

