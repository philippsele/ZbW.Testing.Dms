using System.Collections.Generic;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Windows;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Views;

    internal class LoginViewModel : BindableBase
    {
        private readonly LoginView _loginView;

        private string _benutzername;

        private readonly DocumentManagementService _documentManagementService;
        private readonly IMessageBoxService _messegaBoxService;

        public LoginViewModel(LoginView loginView, IMessageBoxService messageBoxService)
        {
            _loginView = loginView;
            CmdLogin = new DelegateCommand(OnCmdLogin, OnCanLogin);
            CmdAbbrechen = new DelegateCommand(OnCmdAbbrechen);
            _messegaBoxService = messageBoxService;
            
            List<MetadataItem> list = new List<MetadataItem>();
            IImportService importService = new ImportService();
            IExportService exportService = new ExportService();
            IFileService fileService = new FileService(_messegaBoxService);
            ISearchService searchService = new SearchService();
            _documentManagementService = new DocumentManagementService(list, messageBoxService, importService, exportService, fileService, searchService);
            _documentManagementService.RepositoryExists();
        }

        public DelegateCommand CmdAbbrechen { get; }

        public DelegateCommand CmdLogin { get; }

        public string Benutzername
        {
            get
            {
                return _benutzername;
            }

            set
            {
                if (SetProperty(ref _benutzername, value))
                {
                    CmdLogin.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanLogin()
        {
            return !string.IsNullOrEmpty(Benutzername);
        }

        private void OnCmdAbbrechen()
        {
            Application.Current.Shutdown();
        }

        private void OnCmdLogin()
        {
            if (string.IsNullOrEmpty(Benutzername))
            {
                _messegaBoxService.Show("Bitte tragen Sie einen Benutzernamen ein...");
                return;
            }

            if (_documentManagementService.RepositoryExists())
            {
                _documentManagementService.ImportArchiv();
                var searchView = new MainView(Benutzername, _documentManagementService, _messegaBoxService);
                searchView.Show();

                _loginView.Close();
            }
        }
    }
}