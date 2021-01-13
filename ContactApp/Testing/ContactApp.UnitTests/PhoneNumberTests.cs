using System;
using NUnit.Framework;

namespace ContactApp.UnitTests
{
    [TestFixture]
    class PhoneNumberTests
    {
        [Test]
        public void PhoneNumber_CorrectPhoneNumber_ReturnSamePhoneNumber()
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
        public void PhoneNumber_TooLongPhoneNumber_ThrowsException()
        {
            //Setup
            var sourceNumber = 723456789123456789;

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

        public void PhoneNumber_InсorrectPhoneNumber_ThrowsException()
        {
            //Setup
            var sourceNumber = 12346564789;

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
