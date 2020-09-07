using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Testing.Model
{
    [TestFixture]
    class MetadataItemTests
    {
        [Test]
        public void MetadataItem_CreateWithGUID_NoError()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.DokumentenGuid;

            // assert
            Assert.That(result, Is.EqualTo(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8")));
        }

        [Test]
        public void MetadataItem_CreateWithoutGUID_NoError()
        {
            // arrange
            var metadataItem = new MetadataItem("Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.FileName;

            // assert
            Assert.That(result, Is.EqualTo("document.docx"));
        }

        [Test]
        public void DokumentenGuid_Get_GetDokumentenGuid()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.DokumentenGuid;

            // assert
            Assert.That(result, Is.EqualTo(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8")));
        }

        [Test]
        public void Benutzer_Get_GetBenutzer()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.Benutzer;

            // assert
            Assert.That(result, Is.EqualTo("Username"));
        }

        [Test]
        public void Bezeichnung_Get_GetBezeichnung()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.Bezeichnung;

            // assert
            Assert.That(result, Is.EqualTo("Dokumenten Bezeichnung"));
        }

        [Test]
        public void SelectedTypItem_Get_GetSelectedTypItem()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.SelectedTypItem;

            // assert
            Assert.That(result, Is.EqualTo("Verträge"));
        }

        [Test]
        public void Stichwoerter_Get_GetStichwoerter()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.Stichwoerter;

            // assert
            Assert.That(result, Is.EqualTo("Notiz"));
        }

        [Test]
        public void FileName_Get_GetFileName()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.FileName;

            // assert
            Assert.That(result, Is.EqualTo("document.docx"));
        }

        [Test]
        public void Erfassungsdatum_Get_GetErfassungsdatum()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.Erfassungsdatum;

            // assert
            Assert.That(result, Is.EqualTo(DateTime.Parse("01.01.2020 19:00:00")));
        }

        [Test]
        public void ValutaDatum_Get_GetValutaDatum()
        {
            // arrange
            var metadataItem = new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                DateTime.Parse("30.06.2020 00:00:00"), "document.docx");

            // act
            var result = metadataItem.ValutaDatum;

            // assert
            Assert.That(result, Is.EqualTo(DateTime.Parse("30.06.2020 00:00:00")));
        }
    }
}
