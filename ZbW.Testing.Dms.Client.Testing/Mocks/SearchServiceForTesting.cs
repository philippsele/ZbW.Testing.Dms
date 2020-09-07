using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Mocks
{
    class SearchServiceForTesting : ISearchService
    {
        private readonly bool _searchKeywordWithResult;
        private readonly bool _searchDocumentTypeWithResult;
        private readonly bool _searchKeyWordAndTypeWithResult;

        public SearchServiceForTesting(bool searchKeywordWithResult, bool searchDocumentTypeWithResult,
            bool searchKeyWordAndTypeWithResult)
        {
            _searchKeywordWithResult = searchKeywordWithResult;
            _searchDocumentTypeWithResult = searchDocumentTypeWithResult;
            _searchKeyWordAndTypeWithResult = searchKeyWordAndTypeWithResult;
        }

        public List<MetadataItem> SearchKeyword(string keyword, List<MetadataItem> sourceList)
        {
            if (_searchKeywordWithResult)
            {
                return sourceList;
            }
            else
            {
                return new List<MetadataItem>();
            }
        }

        public List<MetadataItem> SearchDocumentType(string documentType, List<MetadataItem> sourceList)
        {
            if (_searchDocumentTypeWithResult)
            {
                return sourceList;
            }
            else
            {
                return new List<MetadataItem>();
            }
        }

        public List<MetadataItem> SearchKeyWordAndType(string keyword, string documentType, List<MetadataItem> sourceList)
        {
            if (_searchKeyWordAndTypeWithResult)
            {
                return sourceList;
            }
            else
            {
                return new List<MetadataItem>();
            }
        }
    }
}
