using Gruden.Data;
using Gruden.Data.Models;
using Gruden.Data.Repos;
using Gruden.Services; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Serilog;
using Serilog.Core;
using System.Xml.Linq;

namespace GrudenTest
{
    [TestClass]
    public class PersonServiceTests : TestBase
    {
        private IPersonService _classtoTest;
        [TestMethod]
        public async Task Name_Is_Saved_To_Repo()

        {
            //Arrange
            var mockSet = new Mock<DbSet<Person>>();
            
            var mockDbFactory = new Mock<IDbContextFactory<PersonDbContext>>();
            mockDbFactory.Setup(f => f.CreateDbContext())
                .Returns(new PersonDbContext(new DbContextOptionsBuilder<PersonDbContext>()
                    .UseInMemoryDatabase("PersonDb")
                    .Options));


            Person person = new Person();

            var repositoryMOQ = new Mock<IPersonRepository>();
            repositoryMOQ.Setup(x => x.SetPersonAsync(person)).Returns( Task.FromResult(new Person { Id= 1, Name= "Dave"})); 

            var loggerMoq = Mock.Of<ILogger<PersonService>>();
           
            _classtoTest = new PersonService(repositoryMOQ.Object, loggerMoq);

            //Act
           
            _responseObject = await _classtoTest.SetPersonAsync(person);

            //Assert

            Assert.IsNotNull(_responseObject);
            Assert.IsTrue(_responseObject.Id == 1, "Id is correct");
            Assert.IsTrue(_responseObject.Name == "Dave", "Name is correct");
        }
    }
}