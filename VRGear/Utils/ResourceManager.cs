using System;
using System.IO;
using UnityEngine;
using System.ComponentModel;

namespace VRGear.Utils
{
    public class ResourceManager
    {
        private readonly string _resourcesFolder;

        public ResourceManager()
        {
            var modFolder = Path.Combine(Environment.CurrentDirectory, nameof(VRGear));
            _resourcesFolder = Path.Combine(modFolder, "Resources");

            if (Directory.Exists(_resourcesFolder) == false)
                Directory.CreateDirectory(_resourcesFolder);

            foreach (var resourceType in Enum.GetValues(typeof(ResourceType)))
            {
                var resourcePath = Path.Combine(_resourcesFolder, resourceType.ToString());

                if (Directory.Exists(resourcePath) == false)
                    Directory.CreateDirectory(resourcePath);
            }
        }

        public string GetResource(ResourceType resourceType, string resourceName)
        {
            if (Enum.IsDefined(typeof(ResourceType), resourceType) == false)
                throw new InvalidEnumArgumentException(nameof(resourceType), (int) resourceType, typeof(ResourceType));

            if (string.IsNullOrWhiteSpace(resourceName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(resourceName));

            var correctResourcePath = Path.Combine(_resourcesFolder, resourceType.ToString());
            var filePath = Path.Combine(correctResourcePath, resourceName);

            if (File.Exists(filePath) == false)
                throw new FileNotFoundException("Can't find file", filePath);

            return filePath;
        }

        public Sprite LoadSprite(string resourceName)
        {
            string filePath = GetResource(ResourceType.Image, resourceName + ".png");
            byte[] bytes = File.ReadAllBytes(filePath);
        
            var texture2D = new Texture2D(512, 512);
        
            // ReSharper disable once InvokeAsExtensionMethod
            if (ImageConversion.LoadImage(texture2D, bytes) == false)
                throw new FileLoadException("file contains not correct data", filePath);
        
            var sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height),
                new Vector2(0.5f, 0.5f), 100f, 0U, 0, default, false);
        
            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        
            return sprite;
        }
    }
}