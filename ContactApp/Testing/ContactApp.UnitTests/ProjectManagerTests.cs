using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace ContactApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTests
    {
        public Project PrepareProject()
        {
            var sourceProject = new Project();
            var sourceNumber = 79528074444;
            var phoneNumber = new PhoneNumber
            {
                Number = sourceNumber
            };

            sourceProject.Contacts.Add(new Contact()
            {
                Name = "Анастасия",
                Surname = "Маркина",
                Birthday = new DateTime(1999, 1, 1),
                IdVk = "12456",
                Email = "Anastas@mail.ru",
                PhoneNumber = phoneNumber
            });

            sourceProject.Contacts.Add(new Contact()
            {
                Name = "Полина",
                Surname = "Пилипенко",
                Birthday = new DateTime(2010, 5, 1),
                IdVk = "12457",
                Email = "Polya@mail.ru",
                PhoneNumber = phoneNumber
            });

            return sourceProject;
        }

        public string TestDataFolder()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData";
            return testDataFolder;
        }

        public string ActualFileName()
        {
            var actualFileName = TestDataFolder() + @"\actualProject.json";
            return actualFileName;
        }

        public string ExpectedFilename()
        {
            var expectedFilename = TestDataFolder() + @"\expectedProject.json";
            return expectedFilename;
        }

        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();
            var testDataFolder = TestDataFolder();
            var actualFileName = ActualFileName();
            var expectedFileName = ExpectedFilename();

            if (File.Exists(actualFileName))
            {
                File.Delete(actualFileName);
            }

            //Act
            ProjectManager.SaveToFile(sourceProject, testDataFolder, actualFileName);
            var isFileExist = File.Exists(actualFileName);
            NUnit.Framework.Assert.AreEqual(true, isFileExist);

            //Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFileName);
            NUnit.Framework.Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [Test]
        public void SaveToFile_NoneExistingFolder_FileSaveCorrectly()
        {
            //Setup
            var sourceProject = PrepareProject();
            var testDataFolder = TestDataFolder();
            var actualFileName = ActualFileName();
            var actualFolder = testDataFolder + @"\TestNoneExistingFolder";

            if (Directory.Exists(actualFolder))
            {
                Directory.Delete(actualFolder, true);
            }

            //Act
            ProjectManager.SaveToFile(sourceProject, actualFolder, actualFileName);

            //Assert
            NUnit.Framework.Assert.True(File.Exists(actualFileName));
        }

        [Test]
        public void LoadFromFile_CorrectFile_FileLoadCorrectly()
        {
            //Setup
            var expectedProject = PrepareProject();
            var expectedFilename = ExpectedFilename();

            //Act
            var actualProject = ProjectManager.LoadFromFile(expectedFilename);

            //Assert
            Assert(expectedProject.Contacts[0], actualProject.Contacts[0]);
            Assert(expectedProject.Contacts[1], actualProject.Contacts[1]);
        }

        [Test]
        public void LoadFromFile_NotCorrectProject_ReturnEmptyProject()
        {
            //Setup
            var testDataFolder = TestDataFolder();
            var actualFileName = testDataFolder + @"\notCorrectlyProject.json";

            //Act
            var actualProject = ProjectManager.LoadFromFile(actualFileName);

            //Assert
            NUnit.Framework.Assert.IsEmpty(actualProject.Contacts);
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
