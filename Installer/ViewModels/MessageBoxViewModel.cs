using ReactiveUI;
using System.Reactive;
using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;

namespace Installer.ViewModels
{
    public class MessageBoxViewModel : ViewModelBase
    {
        public MessageBoxViewModel(Window window, string title, string message)
        {
            OkayCommand = ReactiveCommand.Create(window.Close);
            Title = title;
            ErrorText = message;
        }

        public MessageBoxViewModel()
        {
        }

        public ReactiveCommand<Unit, Unit>? OkayCommand { get; }
        [Reactive] public string? ErrorText { get; set; }
        [Reactive] public string? Title { get; set; }
    }
}