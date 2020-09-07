using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.Testing.Mocks;

namespace ZbW.Testing.Dms.Client.Testing.Services
{
    [TestFixture]
    class DocumentManagementServiceTests
    {
        #region RepositoryExists
        [Test]
        public void RepositoryExists_DeleteBackslashAtTheEndIfExist_StringWithoutBackslash()
        {
            // arrange
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\Temp\\DMS\\");
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            DMS.RepositoryExists();

            // assert
            Assert.That(ConfigurationManager.AppSettings["RepositoryDir"], Is.EqualTo("C:\\Temp\\DMS"));
        }

        [Test]
        public void RepositoryExists_CheckRepositoryPath_False()
        {
            // arrange
            ConfigurationManager.AppSettings.Set("RepositoryDir", "C:\\asdfasdfasdfafecdscs\\DMS\\");
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, false);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.RepositoryExists();

            // assert
            Assert.That(result, Is.EqualTo(false));
        }
        #endregion

        #region ImportArchiv

        [Test]
        public void ImportArchiv_execute_NoException()
        {
            // arrange
            var messegaBoxService = new MessageBoxService();
            var importService = new ImportServiceForTesting(false);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            void Calculation() => DMS.ImportArchiv();

            // assert
            Assert.DoesNotThrow(Calculation);
        }

        [Test]
        public void ImportArchiv_execute2_NoException()
        {
            // arrange
            var messegaBoxService = new MessageBoxService();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            void Calculation() => DMS.ImportArchiv();

            // assert
            Assert.DoesNotThrow(Calculation);
        }

        #endregion

        #region AddNewDocument
        [Test]
        public void AddNewDocument_DocumentNotExists_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, false, true);
            var searchService = new SearchServiceForTesting(true, true, true);    
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.AddNewDocument("Username", "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "C:\\Temp", "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), false) ;

            // assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void AddNewDocument_MoveFileToRepositoryFails_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, false, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.AddNewDocument("Username", "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "C:\\Temp", "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), false);

            // assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void AddNewDocument_ExportServiceFails_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(false);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.AddNewDocument("Username", "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "C:\\Temp", "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), false);

            // assert
            Assert.That(result, Is.EqualTo(false));
        }


        [Test]
        public void AddNewDocument_RemoveFileFails_True() //True --> Da Messagebox informiert, dass File nicht gelöscht werden konnte
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(false, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.AddNewDocument("Username", "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "C:\\Temp", "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), true);

            // assert
            Assert.That(result, Is.EqualTo(true));
        }



        #endregion

        #region SearchDocument

        [Test]
        public void SearchDocument__SearchingOfDocTyp_True()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("", "Verträge");

            // assert
            Assert.That(result, Is.EqualTo(itemlist));
            
        }

        
        [Test]
        public void SearchDocument__SearchingOfDocTyp_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, false, true);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("", "Quittungen");

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        [Test]
        public void SearchDocument__SearchingOfKeyword_True()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("Bezeichnung", null);

            // assert
            Assert.That(result, Is.EqualTo(itemlist));
        }

        [Test]
        public void SearchDocument__SearchingOfKeyword_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(false, true, true);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("AndererText", null);

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        [Test]
        public void SearchDocument__SearchingOfBoth_True()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("Bezeichnung", "Verträge");

            // assert
            Assert.That(result, Is.EqualTo(itemlist));
        }

        [Test]
        public void SearchDocument__SearchingOfBoth_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, false);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("Bezeichnung", "Quittung");

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        [Test]
        public void SearchDocument__SearchingOfBoth2_False()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(true);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, false);
            var itemlist = new List<MetadataItem>();
            itemlist.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            var result = DMS.SearchDocument("AndererText", "Verträge");

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        #endregion

        #region OpenDocument

        [Test]
        public void OpenDocument_execute_NoException()
        {
            // arrange
            var messegaBoxService = new MessageBoxServiceForTesting();
            var importService = new ImportServiceForTesting(false);
            var exportService = new ExportServiceForTesting(true);
            var fileService = new FileServiceForTesting(true, true, true, true);
            var searchService = new SearchServiceForTesting(true, true, true);
            var itemlist = new List<MetadataItem>();
            var DMS = new DocumentManagementService(itemlist, messegaBoxService, importService, exportService, fileService, searchService);

            // act
            void Calculation() => DMS.OpenDocument(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), 2020, "document.docx");

            // assert
            Assert.DoesNotThrow(Calculation);
        }

        #endregion

    }
}
