using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    public interface IFileService
    {
        bool RemoveFile(string path);

        bool MoveFileToRepository(string sourceFile, DateTime valutaDatum, Guid docGuid);

        bool IsDocumentExist(string path);

        bool IsDirectoryExist(string path);

        void OpenDocument(Guid documentGuid, int year, string filename);
    }
}
