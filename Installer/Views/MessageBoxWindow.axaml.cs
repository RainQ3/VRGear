using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Installer.ViewModels;

namespace Installer.Views
{
    public class MessageBoxWindow : Window
    {
        public MessageBoxWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public static void Create(string title, string message)
        {
            var window = new MessageBoxWindow();
            window.DataContext = new MessageBoxViewModel(window, title, message);
            window.Show();
        }
    }
}