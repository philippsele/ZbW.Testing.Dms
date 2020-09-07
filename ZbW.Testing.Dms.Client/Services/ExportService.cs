using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class ExportService : IExportService
    {
        private readonly string _documentPath;
        public ExportService()
        {
            _documentPath = System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"];
        }

        public bool CreateXml(MetadataItem item)
        {
            try
            {
                XmlWriter writer = XmlWriter.Create(_documentPath + "\\" + DateTime.Parse(item.ValutaDatum.ToString()).Year + "\\" + item.DokumentenGuid.ToString() + "_Metadata.xml");
                writer.WriteStartDocument();

                writer.WriteStartElement("DocData");

                writer.WriteAttributeString("DokumentenGuid", item.DokumentenGuid.ToString());
                writer.WriteAttributeString("Benutzer", item.Benutzer);
                writer.WriteAttributeString("Bezeichnung", item.Bezeichnung);
                writer.WriteAttributeString("Erfassungsdatum", item.Erfassungsdatum.ToString());
                writer.WriteAttributeString("ItemTyp", item.SelectedTypItem);
                writer.WriteAttributeString("Stickwoerter", item.Stichwoerter);
                writer.WriteAttributeString("ValutaDatum", item.ValutaDatum.ToString());
                writer.WriteAttributeString("FileName", item.FileName);
                
                writer.WriteEndElement();

                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
