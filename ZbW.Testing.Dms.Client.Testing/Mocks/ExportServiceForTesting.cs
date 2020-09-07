using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Mocks
{
    public class ExportServiceForTesting : IExportService
    {
        private readonly bool _CreateXmlResult;
        public ExportServiceForTesting(bool createXmlResult)
        {
            _CreateXmlResult = createXmlResult;
        }

        public bool CreateXml(MetadataItem item)
        {
            return _CreateXmlResult;
        }
    }
}
