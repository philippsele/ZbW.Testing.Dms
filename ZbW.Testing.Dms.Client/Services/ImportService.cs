using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class ImportService : IImportService
    {
        private readonly string _documentPath;
        public ImportService()
        {
            _documentPath = System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"];
        }

        public List<MetadataItem> GetDocumentList()
        {
            List<MetadataItem> returnList = new List<MetadataItem>();
            foreach (var yearDirectory in Directory.GetDirectories(_documentPath))
            {
                foreach (var file in Directory.GetFiles(yearDirectory))
                {
                    if (file.EndsWith("_Metadata.xml"))
                    {
                        try
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(file);

                            Guid dokumentenGuid = Guid.Parse(xmlDocument.DocumentElement.GetAttribute("DokumentenGuid"));

                            string benutzer = xmlDocument.DocumentElement.GetAttribute("Benutzer");

                            string bezeichnung = xmlDocument.DocumentElement.GetAttribute("Bezeichnung");

                            DateTime erfassungsdatum = DateTime.Parse(xmlDocument.DocumentElement.GetAttribute("Erfassungsdatum"));

                            string selectedTypItem = xmlDocument.DocumentElement.GetAttribute("ItemTyp");

                            string stichwoerter = xmlDocument.DocumentElement.GetAttribute("Stickwoerter");

                            DateTime valutaDatum = DateTime.Parse(xmlDocument.DocumentElement.GetAttribute("ValutaDatum"));

                            string fileName = xmlDocument.DocumentElement.GetAttribute("FileName");

                            MetadataItem item = new MetadataItem(dokumentenGuid, benutzer, bezeichnung, erfassungsdatum, selectedTypItem, stichwoerter, valutaDatum, fileName);

                            returnList.Add(item);
                        }
                        catch (Exception e)
                        {
                            returnList = new List<MetadataItem>();
                            return returnList;
                        }

                    }
                }
            }

            return returnList;
        }
    }
}
