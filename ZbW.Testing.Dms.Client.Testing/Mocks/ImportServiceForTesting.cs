using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Mocks
{
    class ImportServiceForTesting : IImportService
    {
        private readonly bool _getDocumentListWithResult;
        public ImportServiceForTesting(bool getDocumentListWithResult)
        {
            _getDocumentListWithResult = getDocumentListWithResult;
        }

        public List<MetadataItem> GetDocumentList()
        {
            List<MetadataItem> list = new List<MetadataItem>();
            if (_getDocumentListWithResult)
            {
                list.Add(new MetadataItem(Guid.Parse("3fc6a223-369b-4efd-a0c4-f563ee6d67f8"), "Username",
                    "Dokumenten Bezeichnung", DateTime.Parse("01.01.2020 19:00:00"), "Verträge", "Notiz",
                    DateTime.Parse("30.06.2020 00:00:00"), "document.docx"));
            }
            return list;
        }
    }
}
