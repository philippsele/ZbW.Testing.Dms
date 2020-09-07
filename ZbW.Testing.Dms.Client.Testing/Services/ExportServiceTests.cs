using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Services
{
    [TestFixture]
    class ExportServiceTests
    {
        [OneTimeSetUp]
        public void SetupDirectoriesAndFiles()
        {
            Directory.CreateDirectory("C:\\Temp\\UnitTestingOfPhilipp\\Repository\\2020");
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\Temp\\UnitTestingOfPhilipp\\Repository");
        }


        [Test]
        public void CreateXml_IsFileCreated_FileExists()
        {
            // arrange
            var exportService = new ExportService();
            var TestItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = exportService.CreateXml(TestItem);
            var IsFileExist =
                File.Exists(
                    "C:\\Temp\\UnitTestingOfPhilipp\\Repository\\2020\\3fc6a223-369b-4efd-a0c4-f563ee6d67f8_Metadata.xml");

            // assert
            Assert.That(IsFileExist, Is.EqualTo(true));
        }

        [Test]
        public void CreateXml_Execute_True()
        {
            // arrange
            var exportService = new ExportService();
            var TestItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = exportService.CreateXml(TestItem);

            // assert
            Assert.That(result, Is.EqualTo(true));
        }


        [OneTimeTearDown]
        public void DeleteDirectory()
        {
            Directory.Delete("C:\\Temp\\UnitTestingOfPhilipp", true);
        }
    }
}
