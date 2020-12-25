using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace ContactApp.UnitTests
{
    [TestFixture]
    class ProjectTests
    {
        [Test]
        public void Project_CreateProject_ReturnAdjustedProject()
        {
            //Setup
            var sourceNumber = 71234567891;
            var phoneNumber = new PhoneNumber
            {
                Number = sourceNumber
            };

            var contact = new Contact
            {
                Name = "Имя",
                Surname = "Фамилия",
                Birthday = new DateTime(2000, 2, 1),
                Email = "email@mail.com",
                IdVk = "id123",
                PhoneNumber = phoneNumber
            };

            var sourceProject = new Project();

            //Act
            sourceProject.Contacts.Add(contact);

            //Assert
            NUnit.Framework.Assert.IsNotNull(sourceProject);
        }
    }
}

