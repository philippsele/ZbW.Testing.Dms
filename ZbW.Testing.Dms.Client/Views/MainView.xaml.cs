

namespace ZbW.Testing.Dms.Client.Views
{
    using System.Windows;

    using ZbW.Testing.Dms.Client.ViewModels;
    using ZbW.Testing.Dms.Client.Services;

    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(string benutzername, DocumentManagementService documentManagementService, IMessageBoxService messegaBoxService)
        {
            InitializeComponent();
            DataContext = new MainViewModel(benutzername, documentManagementService, messegaBoxService);
        }
    }
}