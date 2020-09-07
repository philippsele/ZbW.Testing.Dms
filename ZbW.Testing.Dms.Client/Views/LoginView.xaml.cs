using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Views
{
    using System.Windows;

    using ZbW.Testing.Dms.Client.ViewModels;

    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            IMessageBoxService messageBoxService = new MessageBoxService();
            DataContext = new LoginViewModel(this, messageBoxService);
        }
    }
}