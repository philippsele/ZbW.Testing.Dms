using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Testing.Mocks
{
    class FileServiceForTesting : IFileService
    {
        private readonly bool _RemoveFileResult;
        private readonly bool _MoveFileToRepositoryResult;
        private readonly bool _IsDocumentExistResult;
        private readonly bool _IsDirectoryExistResult;


        public FileServiceForTesting(bool removeFileResult, bool moveFileToRepositoryResult, bool isDocumentExistResult,
            bool isDirectoryExistResult)
        {
            _RemoveFileResult = removeFileResult;
            _MoveFileToRepositoryResult = moveFileToRepositoryResult;
            _IsDocumentExistResult = isDocumentExistResult;
            _IsDirectoryExistResult = isDirectoryExistResult;
        }

        public bool RemoveFile(string path)
        {
            return _RemoveFileResult;
        }

        public bool MoveFileToRepository(string sourceFile, DateTime valutaDatum, Guid docGuid)
        {
            return _MoveFileToRepositoryResult;
        }

        public bool IsDocumentExist(string path)
        {
            return _IsDocumentExistResult;
        }

        public bool IsDirectoryExist(string path)
        {
            return _IsDirectoryExistResult;
        }

        public void OpenDocument(Guid documentGuid, int year, string filename)
        {
        }
    }
}
