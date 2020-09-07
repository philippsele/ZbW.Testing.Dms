using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Services
{
    [TestFixture]
    class ImportServiceTests
    {
        [OneTimeSetUp]
        public void SetupDirectoriesAndFiles()
        {
            Directory.CreateDirectory("C:\\Temp\\UnitTestingOfPhilipp\\Repository\\2020");
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\Temp\\UnitTestingOfPhilipp\\Repository");
            var exportService = new ExportService();
            exportService.CreateXml(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
        }


        [Test]
        public void GetDocumentList_ExecuteWithEmptyDirectory_EmptyList()
        {
            // arrange
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\Temp\\UnitTestingOfPhilipp");
            var importService = new ImportService();

            // act
            var result = importService.GetDocumentList();

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        [Test]
        public void GetDocumentList_ImportFile_List()
        {
            // arrange
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\Temp\\UnitTestingOfPhilipp\\Repository");
            var importService = new ImportService();

            // act
            var result = importService.GetDocumentList();

            // assert
            Assert.That(result.Count, Is.EqualTo(1));
        }


        [OneTimeTearDown]
        public void DeleteDirectory()
        {
            Directory.Delete("C:\\Temp\\UnitTestingOfPhilipp", true);
        }
    }
}
