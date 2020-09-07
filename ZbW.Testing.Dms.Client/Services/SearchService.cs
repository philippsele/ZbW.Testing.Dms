using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class SearchService : ISearchService
    {
        public List<MetadataItem> SearchKeyword(string keyword, List<MetadataItem> sourceList)
        {
            List<MetadataItem> searchResult = new List<MetadataItem>();

            foreach (var document in sourceList)
            {
                if (document.Bezeichnung.Contains(keyword) || document.Stichwoerter.Contains(keyword))
                {
                    searchResult.Add(document);
                }
            }

            return searchResult;
        }

        public List<MetadataItem> SearchDocumentType(string documentType, List<MetadataItem> sourceList)
        {
            List<MetadataItem> searchResult = new List<MetadataItem>();

            foreach (var document in sourceList)
            {
                if (document.SelectedTypItem == documentType)
                {
                    searchResult.Add(document);
                }
            }

            return searchResult;
        }

        public List<MetadataItem> SearchKeyWordAndType(string keyword, string documentType, List<MetadataItem> sourceList)
        {
            List<MetadataItem> searchResult = new List<MetadataItem>();

            foreach (var document in sourceList)
            {
                if (document.SelectedTypItem == documentType && (document.Bezeichnung.Contains(keyword) || document.Stichwoerter.Contains(keyword)))
                {
                    searchResult.Add(document);
                }
            }

            return searchResult;
        }
    }
}
