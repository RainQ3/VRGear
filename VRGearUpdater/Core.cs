using System;
using System.IO;
using System.Net;
using MelonLoader;

namespace VRGearUpdater
{
    public class Core : MelonPlugin
    {
        public override void OnApplicationStart()
        {

            string modsFolderPath = Path.Combine(Environment.CurrentDirectory, "Mods");
            string modFile = Path.Combine(modsFolderPath, "VRGear.dll");

            if (Directory.Exists(modsFolderPath))
            {
                if (File.Exists(modFile))
                    File.Delete(modFile);
            }
            else
            {
                Directory.CreateDirectory(modsFolderPath);
            }
            
            var webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("https://github.com/PureFoxCore/VRGear/releases/latest/download/VRGear.dll"), modFile);
        }
    }
}