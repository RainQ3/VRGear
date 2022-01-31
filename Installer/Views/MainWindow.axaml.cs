using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Installer.ViewModels;

namespace Installer.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new MainWindowViewModel(this);
        }
    }
}