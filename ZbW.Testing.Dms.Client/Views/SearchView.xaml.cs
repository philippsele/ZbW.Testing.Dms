using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Views
{
    using System.Windows.Controls;

    using ZbW.Testing.Dms.Client.ViewModels;

    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView(DocumentManagementService documentManagementService, IMessageBoxService messegaBoxService)
        {
            InitializeComponent();
            DataContext = new SearchViewModel(documentManagementService, messegaBoxService);
        }
    }
}