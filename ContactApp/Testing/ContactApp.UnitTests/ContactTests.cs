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
        public void Name_EnprtyName_DefaultName()
        {
            //Setup
            var contact = new Contact();
            var sourceName = "";
            var expectedName = "Name isn't written";

            //Act
            contact.Name = sourceName;
            var actualName = contact.Name;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
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

        public static void Assert(Contact contact1, Contact contact2)
        {
            NUnit.Framework.Assert.AreEqual(contact1.Name, contact2.Name);
            NUnit.Framework.Assert.AreEqual(contact1.Surname, contact2.Surname);
            NUnit.Framework.Assert.AreEqual(contact1.PhoneNumber, contact2.PhoneNumber);
            NUnit.Framework.Assert.AreEqual(contact1.Email, contact2.Email);
            NUnit.Framework.Assert.AreEqual(contact1.Birthday, contact2.Birthday);
            NUnit.Framework.Assert.AreEqual(contact1.IdVk, contact2.IdVk);
        }
    }
}

