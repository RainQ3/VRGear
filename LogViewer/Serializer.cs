using System;
using System.IO;
using System.Xml.Serialization;

namespace LogViewer
{
    public class Serializer<T>
    {
        private readonly string _filePath;
        private readonly XmlSerializer _formatter;

        public Serializer(string filePath)
        {
            _filePath = filePath;
            _formatter = new XmlSerializer(typeof(T));
        }

        public void Serialize(T model)
        {
            var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
            _formatter.Serialize(fileStream, model);
            fileStream.Close();
        }

        public T Deserialize()
        {
            var fileStream = new FileStream(_filePath, FileMode.Open);
            object? data = _formatter.Deserialize(fileStream);
            fileStream.Close();

            if (data == null)
                throw new NullReferenceException("Can't deserialize object");
            
            return (T) data;
        }
    }
}