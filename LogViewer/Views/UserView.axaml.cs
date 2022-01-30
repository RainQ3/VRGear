using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LogViewer.Views
{
    public class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}