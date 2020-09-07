using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class DocumentManagementService
    {
        private List<MetadataItem> _documentList;

        private readonly IMessageBoxService _messageBoxService;
        private readonly IImportService _importService;
        private readonly IExportService _exportService;
        private readonly IFileService _fileService;
        private readonly ISearchService _searchService;
        public DocumentManagementService(List<MetadataItem> documentList, IMessageBoxService messageBoxService, IImportService importService, IExportService exportService, IFileService fileService, ISearchService searchService)
        {
            _documentList = documentList;
            _messageBoxService = messageBoxService;
            _importService = importService;
            _exportService = exportService;
            _fileService = fileService;
            _searchService = searchService;
        }

        public bool RepositoryExists()
        {
            string documentPath = System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"];
            if (_fileService.IsDirectoryExist(documentPath))
            {
                if (documentPath.EndsWith("\\"))
                {
                    System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"] = System.Configuration
                        .ConfigurationManager.AppSettings["RepositoryDir"].Substring(0,
                            System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"].Length - 1);
                }

                return true;
            }
            else
            {
                _messageBoxService.Show("Der im 'App.config' angegebene Pfad kann nicht gefunden werden. Bitte anpassen und Programm neu starten!");
                //Application.Current.Shutdown();
                return false;
            }
        }

        public void ImportArchiv()
        {
            _documentList = _importService.GetDocumentList();
        }

        public bool AddNewDocument(string benutzer, string bezeichnung, DateTime erfassungsdatum, string filePath, string selectedTypItem, string stichwoerter, DateTime valutaDatum, bool isRemoveFileEnabled)
        {
            if (!_fileService.IsDocumentExist(filePath))
            {
                return false;
            }

            MetadataItem item = new MetadataItem(benutzer, bezeichnung, erfassungsdatum, selectedTypItem, stichwoerter, valutaDatum, filePath.Split('\\').Last());
            

            if (!_fileService.MoveFileToRepository(filePath, item.ValutaDatum, item.DokumentenGuid) || !_exportService.CreateXml(item))
            {
                return false;
            }

            _documentList.Add(item);

            if (isRemoveFileEnabled)
            {
                _fileService.RemoveFile(filePath);
            }
                
            return true;
        }

        public List<MetadataItem> SearchDocument(string suchbegriff, string documentTyp)
        {
            List<MetadataItem> returnList = new List<MetadataItem>();

            if (!string.IsNullOrEmpty(suchbegriff) && !string.IsNullOrEmpty(documentTyp))
            {
                returnList = _searchService.SearchKeyWordAndType(suchbegriff, documentTyp, _documentList);
            }

            if (string.IsNullOrEmpty(suchbegriff) && !string.IsNullOrEmpty(documentTyp))
            {
                returnList = _searchService.SearchDocumentType(documentTyp, _documentList);
            }

            if (!string.IsNullOrEmpty(suchbegriff) && string.IsNullOrEmpty(documentTyp))
            {
                returnList = _searchService.SearchKeyword(suchbegriff, _documentList);
            }

            return returnList;
        }

        public void OpenDocument(Guid documentGuid, int year, string fileName)
        {
            _fileService.OpenDocument(documentGuid, year, fileName);
        }

    }
}
