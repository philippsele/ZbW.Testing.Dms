using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.Testing.Mocks;

namespace ZbW.Testing.Dms.Client.Testing.Services
{
    [TestFixture]
    class FileServiceTests
    {
        [OneTimeSetUp]
        public void SetupFiles()
        {
            Directory.CreateDirectory("C:\\Temp\\UnitTestingOfPhilipp\\Repository");
            File.Create("C:\\Temp\\UnitTestingOfPhilipp\\Test.txt").Dispose();
            File.Create("C:\\Temp\\UnitTestingOfPhilipp\\Test2.txt").Dispose();
            File.Create("C:\\Temp\\UnitTestingOfPhilipp\\Test3.txt").Dispose();
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\Temp\\UnitTestingOfPhilipp\\Repository");
        }

        #region RemoveFile

        [Test]
        public void RemoveFile_DeleteFile_True()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting(); 
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.RemoveFile("C:\\Temp\\UnitTestingOfPhilipp\\Test3.txt");

            // assert
            Assert.That(result, Is.EqualTo(true));
        }

        #endregion


        #region MoveFileToRepository

        [Test]
        public void MoveFileToRepository_Execute_True()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting();
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.MoveFileToRepository("C:\\Temp\\UnitTestingOfPhilipp\\Test.txt", DateTime.Now, Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"));

            // assert
            Assert.That(result, Is.EqualTo(true));
        }

        #endregion

        #region IsDocumentExist

        [Test]
        public void IsDocumentExist_StringEmpty_False()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting();
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.IsDocumentExist("");

            // assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void IsDocumentExist_NotExisting_False()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting();
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.IsDocumentExist("C:\\Temp\\UnitTestingOfPhilipp\\efoinraeoignr.mkd");

            // assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void IsDocumentExist_FileExists_True()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting();
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.IsDocumentExist("C:\\Temp\\UnitTestingOfPhilipp\\Test.txt");

            // assert
            Assert.That(result, Is.EqualTo(true));
        }

        #endregion

        #region IsDirectoryExist

        [Test]
        public void IsDirectoryExistt_NotExisting_False()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting();
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.IsDirectoryExist("C:\\Temp\\UnitTestingOfPhilipp\\efoinraeoignr");

            // assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void IsDirectoryExist_Exists_True()
        {
            // arrange
            var messageboxService = new MessageBoxServiceForTesting();
            var fileService = new FileService(messageboxService);

            // act
            var result = fileService.IsDirectoryExist("C:\\Temp\\UnitTestingOfPhilipp");

            // assert
            Assert.That(result, Is.EqualTo(true));
        }

        #endregion


        #region OpenDocument

        // nothing to test

        #endregion
    }
}
