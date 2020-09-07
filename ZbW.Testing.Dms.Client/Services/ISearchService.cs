using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public interface ISearchService
    {
        List<MetadataItem> SearchKeyword(string keyword, List<MetadataItem> sourceList);

        List<MetadataItem> SearchDocumentType(string documentType, List<MetadataItem> sourceList);

        List<MetadataItem> SearchKeyWordAndType(string keyword, string documentType, List<MetadataItem> sourceList);
    }
}
