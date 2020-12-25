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
    class PhoneNumberTests
    {
        [Test]
        public void PhoneNumber_CorreclyPhoneNumber_ReturnPhoneNumber()
        {
            //Setup
            var sourceNumber = 79528074444;
            var phoneNumber = new PhoneNumber
            {
                Number = sourceNumber
            };

            //Act
            var actualyPhoneNumber = phoneNumber;

            //Assert
            NUnit.Framework.Assert.AreEqual(actualyPhoneNumber.Number, sourceNumber);
        }

        [Test]
        public void Birthday_TooSmallBirthday_ThrowsException()
        {
            //Setup
            var sourceNumber = 123456789123456789;

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>

                {
                    //Act
                    var phoneNumber = new PhoneNumber
                    {
                        Number = sourceNumber
                    };
                }
            );
        }
    }
}
