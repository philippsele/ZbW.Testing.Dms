using System;
using System.Collections.Generic;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Services
{
    [TestFixture]
    class SearchServiceTests
    {
        [Test]
        public void SearchDocumentType_SearchingOfDocTyp_True()
        {
            // arrange
            List<MetadataItem> itemList = new List<MetadataItem>();
            itemList.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            SearchService searchService = new SearchService();

            // act
            var result = searchService.SearchDocumentType("Verträge", itemList);

            // assert
            Assert.That(result, Is.EqualTo(itemList));
        }

        [Test]
        public void SearchDocumentType_SearchingOfDocTyp_False()
        {
            // arrange
            List<MetadataItem> itemList = new List<MetadataItem>();
            itemList.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            SearchService searchService = new SearchService();

            // act
            var result = searchService.SearchDocumentType("Quittungen", itemList);

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        [Test]
        public void SearchKeyword_SearchingOfKeywords_True()
        {
            // arrange
            List<MetadataItem> itemList = new List<MetadataItem>();
            itemList.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            SearchService searchService = new SearchService();

            // act
            var result = searchService.SearchKeyword("Notiz", itemList);

            // assert
            Assert.That(result, Is.EqualTo(itemList));
        }

        [Test]
        public void SearchKeyword_SearchingOfKeywords_False()
        {
            // arrange
            List<MetadataItem> itemList = new List<MetadataItem>();
            itemList.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            SearchService searchService = new SearchService();

            // act
            var result = searchService.SearchKeyword("Verträge", itemList);

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }

        [Test]
        public void SearchKeyWordAndType_SearchingOfBoth_True()
        {
            // arrange
            List<MetadataItem> itemList = new List<MetadataItem>();
            itemList.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            SearchService searchService = new SearchService();

            // act
            var result = searchService.SearchKeyWordAndType("Notiz", "Verträge", itemList);

            // assert
            Assert.That(result, Is.EqualTo(itemList));
        }

        [Test]
        public void SearchKeyWordAndType_SearchingOfBoth_False()
        {
            // arrange
            List<MetadataItem> itemList = new List<MetadataItem>();
            itemList.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            SearchService searchService = new SearchService();

            // act
            var result = searchService.SearchKeyWordAndType("Baum", "Quittungen", itemList);

            // assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem>()));
        }
    }
}
