using System;
using NUnit.Framework;

namespace ContactApp.UnitTests
{
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Name_GoodName_ReturnsSameName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "Contact1";
            var expectedName  = sourceName;

            //Act
            contact.Name = sourceName;
            var actualName  = contact.Name;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_LowCaseName_ReturnsUpperCaseName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "имя";
            var expectedName = "Имя";

            //Act
            contact.Name = sourceName;
            var actualName = contact.Name;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_EmprtyName_DefaultName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
                (
                () =>
                {
                    //Act
                    contact.Name = sourceName;
                }
            );
        }

        [Test]
        public void Name_TooLongName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "Contact Contact Contact Contact Contact Contact Contact Contact";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>

                { 
                    //Act
                    contact.Name = sourceName; 
                }
            );                          
        }

        [Test]
        public void Surname_GoodName_ReturnsSameSurname()
        {
            //Setup

            var contact = new Contact();
            var sourceSurname = "Contact1";
            var expectedSurname = sourceSurname;

            //Act
            contact.Surname = sourceSurname;
            var actualSurname = contact.Surname;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedSurname, actualSurname);
        }

        [Test]
        public void Surname_LowCaseName_ReturnsUpperCaseSurname()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "фамилия";
            var expectedSurname = "Фамилия";

            //Act
            contact.Surname = sourceSurname;
            var actualName = contact.Surname;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedSurname, actualName);
        }

        [Test]
        public void Surname_EmprtyName_DefaultSurname()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
                (
                () =>
                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Surname_TooLongName_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceSurname = "Contact Contact Contact Contact Contact Contact Contact Contact";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Surname = sourceSurname;
                }
            );
        }

        [Test]
        public void Email_GoodEmail_ReturnSameEmail()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "email@mail.com";
            var expectedEmail = sourceEmail;

            //Act
            contact.Email = sourceEmail;
            var actualEmail = contact.Email;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void Email_TooLongEmail_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceEmail = "Email Email Email Email Email Email Email Email Email Email Email Email";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Email = sourceEmail;
                }
            );
        }

        [Test]
        public void IdVk_GoodIdVk_ReturnSameIdVk()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "email@mail.com";
            var expectedIdVk = sourceIdVk;

            //Act
            contact.IdVk = sourceIdVk;
            var actualIdVk = contact.IdVk;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedIdVk, actualIdVk);
        }

        [Test]
        public void IdVk_TooLongIdVk_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceIdVk = "IdVk IdVk IdVk IdVk IdVk IdVk IdVk";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.IdVk = sourceIdVk;
                }
            );
        }

        [Test]
        public void Birthday_GoodBirthday_ReturnSameBirthday()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthday = new DateTime(2000, 1, 1);
            var expectedBirthday = sourceBirthday;

            //Act
            contact.Birthday = sourceBirthday;
            var actualBirthday = contact.Birthday;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedBirthday, actualBirthday);
        }

        [Test]
        public void Birthday_TooSmallBirthday_ThrowsException()
        {
            //Setup
            var contact = new Contact();
            var sourceBirthday = new DateTime(1800, 1, 1);

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    contact.Birthday = sourceBirthday;
                }
            );
        }

        [Test]
        public void Clone_CorrectContact_ReturnCorrectContact()
        {
            //Setup
            var sourceNumber = 79528074444;
            var phoneNumber = new PhoneNumber
            {
                Number = sourceNumber
            };
            var expectedContact = new Contact
            {
                Name = "Анастасия",
                Surname = "Маркина",
                Birthday = new DateTime(1999, 1, 1),
                IdVk = "12456",
                Email = "Anastas@mail.ru",
                PhoneNumber = phoneNumber
            };

            //Act
            var actualContact = expectedContact.Clone() as Contact;

            //Assert
            Assert(expectedContact, actualContact);            
        }
        public static void Assert(Contact contact1, Contact contact2)
        {
            NUnit.Framework.Assert.AreEqual(contact1.Name, contact2.Name);
            NUnit.Framework.Assert.AreEqual(contact1.Surname, contact2.Surname);
            NUnit.Framework.Assert.AreEqual(contact1.PhoneNumber.Number, contact2.PhoneNumber.Number);
            NUnit.Framework.Assert.AreEqual(contact1.Email, contact2.Email);
            NUnit.Framework.Assert.AreEqual(contact1.Birthday, contact2.Birthday);
            NUnit.Framework.Assert.AreEqual(contact1.IdVk, contact2.IdVk);
        }
    }
}

