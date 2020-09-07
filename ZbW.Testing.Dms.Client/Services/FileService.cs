using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FileService : IFileService
    {
        private readonly string _documentPath;
        private readonly IMessageBoxService _messageBoxService;
        public FileService(IMessageBoxService messageBoxService)
        {
            _documentPath = System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"];
            _messageBoxService = messageBoxService;
        }

        public bool RemoveFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                _messageBoxService.Show("Datei konnte nicht gelöscht werden.");
                return false;
            }

            return true;
        }

        public bool MoveFileToRepository(string sourceFile, DateTime valutaDatum, Guid docGuid)
        {
            int year = DateTime.Parse(valutaDatum.ToString()).Year;

            try
            {
                Directory.CreateDirectory(_documentPath + "\\" + year.ToString());
            }
            catch (Exception e)
            {
                _messageBoxService.Show("Es können keine Ordner im Archiv erstellt werden.");
                return false;
            }
            

            try
            {
                File.Copy(sourceFile, _documentPath + "\\" + year.ToString() + "\\" + docGuid.ToString() + "_Content." + sourceFile.Split('.').Last());
            }
            catch (Exception e)
            {
                _messageBoxService.Show("Datei konnte nicht ins Repository kopiert werden.");
                return false;
            }

            return true;
        }

        public bool IsDocumentExist(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                _messageBoxService.Show("Es wurde kein Dokument ausgewählt!");
            }

            if (File.Exists(path) == false)
            {
                _messageBoxService.Show("Datei existiert nicht");
                return false;
            }

            return true;
        }

        public bool IsDirectoryExist(string path)
        {
            if (!Directory.Exists(path))
            {
                _messageBoxService.Show("Der im 'App.config' angegebene Pfad kann nicht gefunden werden. Bitte anpassen und Programm neu starten!");
                return false;
            }

            return true;
        }

        public void OpenDocument(Guid documentGuid, int year, string filename)
        {
            try
            {
                Process.Start(_documentPath + "\\" + year.ToString() + "\\" + documentGuid.ToString() + "_Content." + filename.Split('.').Last());
            }
            catch (Exception e)
            {
                _messageBoxService.Show("Datei kann nicht geöffnet werden.");
            }
            
        }
    }
}
