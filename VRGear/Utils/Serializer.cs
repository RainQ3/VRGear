using System;
using System.IO;
using System.Xml.Serialization;

namespace VRGear.Utils
{
    public class Serializer<T>
    {
        private readonly string _configFolder;
        private readonly string _fileName;
        private readonly XmlSerializer _formatter;

        public Serializer(string fileName, ResourceType resourceType)
        {
            _fileName = resourceType == ResourceType.Log ? $"{fileName}_{DateTime.Now:yy-MM-dd_hh-mm-ss}" : fileName;
            _formatter = new XmlSerializer(typeof(T));
            _configFolder = Path.Combine(Path.Combine(Environment.CurrentDirectory, nameof(VRGear)), resourceType.ToString());

            if (Directory.Exists(_configFolder) == false)
                Directory.CreateDirectory(_configFolder);
        }

        public bool CanDeserialize => File.Exists(FilePath) == false;
        private string FilePath => Path.Combine(_configFolder, _fileName) + ".xml";

        public void Serialize(T model)
        {
            var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);
            _formatter.Serialize(fileStream, model);
            fileStream.Close();
        }

        public T Deserialize()
        {
            var fileStream = new FileStream(FilePath, FileMode.Open);
            object data = _formatter.Deserialize(fileStream);
            fileStream.Close();

            if (data == null)
                throw new NullReferenceException("Can't deserialize object");

            return (T) data;
        }
    }
}