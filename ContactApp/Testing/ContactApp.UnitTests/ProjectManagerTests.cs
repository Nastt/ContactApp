using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.UnitTests
{
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class ProjectManagerTests
    {
        public Project SetUp()
        {
            var sourceProject = new Project();
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "Анастасия",
                Surname = "Маркина",
                IdVk = "12456",
                Email = "Anastas@mail.ru",

            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "Полина",
                Surname = "Пилипенко",
                IdVk = "12457",
                Email = "Polya@mail.ru",
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
            var sourceProject = new Project();
            sourceProject = SetUp();

            var testDataFolder = TestDataFolder();
            var actualFileName = ActualFileName();
            var expectedFileName = ExpectedFilename();

            if (File.Exists(actualFileName))
            {
                File.Delete(actualFileName);
            }

            //Act
            ProjectManager.SaveToFile(sourceProject, testDataFolder, actualFileName);

            //Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFileName);
            NUnit.Framework.Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [Test]
        public void SaveToFile_NoneExistingFolder_FileSaveCorrectly()
        {
            //Setup
            var sourceProject = SetUp();
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
            var expectedProject = SetUp();
            var expectedFilename = ExpectedFilename();
            var actualFileName = ActualFileName();

            //Act
            var actualProject = ProjectManager.LoadFromFile(expectedFilename);

            //Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFilename);
            NUnit.Framework.Assert.AreEqual(expectedFileContent, actualFileContent);
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
            Assert.IsEmpty(actualProject.Contacts);
        }
    }
}
