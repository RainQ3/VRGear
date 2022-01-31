using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reactive;
using Avalonia.Controls;
using Installer.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Installer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Window? _window;

        public MainWindowViewModel(Window window)
        {
            _window = window;
            SelectExe = ReactiveCommand.Create(Select);

            InstallMod = ReactiveCommand.Create(() =>
            {
                if (string.IsNullOrWhiteSpace(AppPath))
                {
                    MessageBoxWindow.Create("Error", "Select VRChat executable");
                    return;
                }

                string modsFolderPath = Path.Combine(AppPath.Replace("VRChat.exe", ""), "Mods");

                if (Directory.Exists(modsFolderPath) == false)
                    Directory.CreateDirectory(modsFolderPath);

                var webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri(""), Path.Combine(modsFolderPath, "VRGear.dll"));
            });

            InstallPlugin = ReactiveCommand.Create(() =>
            {
                if (string.IsNullOrWhiteSpace(AppPath))
                {
                    MessageBoxWindow.Create("Error", "Select VRChat executable");
                    return;
                }

                string pluginsFolderPath = Path.Combine(AppPath.Replace("VRChat.exe", ""), "Plugins");

                if (Directory.Exists(pluginsFolderPath) == false)
                    Directory.CreateDirectory(pluginsFolderPath);

                var webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri(""), Path.Combine(pluginsFolderPath, "VRGearUpdater.dll"));
            });
        }

        private async void Select()
        {
            OpenFileDialog fileDialog = new()
            {
                Filters = new List<FileDialogFilter> {new() {Name = "VRChat", Extensions = new List<string> {"exe"}}},
                AllowMultiple = false,
                Title = "Select VRChat exe"
            };
            string? selectedFile = (await fileDialog.ShowAsync(_window!))?[0];

            if (selectedFile!.ToLower().EndsWith("VRChat.exe".ToLower()) == false)
            {
                MessageBoxWindow.Create("Error", "Selected file is not VRChat executable");
                return;
            }

            AppPath = selectedFile;
        }

        public MainWindowViewModel()
        {
        }

        public ReactiveCommand<Unit, Unit>? SelectExe { get; }
        public ReactiveCommand<Unit, Unit>? InstallMod { get; }
        public ReactiveCommand<Unit, Unit>? InstallPlugin { get; }

        [Reactive] public string? AppPath { get; set; }
    }
}