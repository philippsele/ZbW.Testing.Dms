using System;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        public Guid DokumentenGuid { get; set; }

        public string Benutzer { get; set; }

        public string Bezeichnung { get; set; }

        public DateTime Erfassungsdatum { get; set; }

        public string SelectedTypItem { get; set; }

        public string Stichwoerter { get; set; }

        public DateTime ValutaDatum { get; set; }

        public string FileName { get; set; }

        public MetadataItem(Guid dokumentenGuid, string benutzer, string bezeichnung, DateTime erfassungsdatum,
            string selectedTypItem, string stichwoerter, DateTime valutaDatum, string fileName) // GUID vorhanden (bestehendes Dok)
        {
            DokumentenGuid = dokumentenGuid;
            Benutzer = benutzer;
            Bezeichnung = bezeichnung;
            Erfassungsdatum = erfassungsdatum;
            SelectedTypItem = selectedTypItem;
            Stichwoerter = stichwoerter;
            ValutaDatum = valutaDatum;
            FileName = fileName;
        }

        public MetadataItem(string benutzer, string bezeichnung, DateTime erfassungsdatum,
            string selectedTypItem, string stichwoerter, DateTime valutaDatum, string fileName) // GUID nicht vorhanden (neues Dok)
        {
            DokumentenGuid = Guid.NewGuid();
            Benutzer = benutzer;
            Bezeichnung = bezeichnung;
            Erfassungsdatum = erfassungsdatum;
            SelectedTypItem = selectedTypItem;
            Stichwoerter = stichwoerter;
            ValutaDatum = valutaDatum;
            FileName = fileName;
        }
    }
}