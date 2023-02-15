using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Source.Serialization
{
    public class JsonStorage
    {
        private string _directoryPath;
        private string[] _filePathes;
        private List<Folder> _folders;

        public JsonStorage()
        {
            var _directoryPath = UnityEngine.Application.persistentDataPath + "/savesJson";

            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            
            var files = Directory.GetFiles(_directoryPath);

            _folders = new List<Folder>();
            foreach (var file in files)
            {
                Folder folder = JsonConvert.DeserializeObject<Folder>(File.ReadAllText(file));
                _folders.Add(folder);
            }
            
        }

        // public void Save(object saveData)
        // {
        //     var jsonData = JsonConvert.SerializeObject(saveData);
        //
        //     File.WriteAllText(_filePath, jsonData);
        // }
        //
        // public object Load()
        // {
        //     if (!File.Exists(_filePath))
        //         return null;
        //
        //     //var savedData = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(_filePath));
        //     //return savedData;
        //     return null;
        // }
    }
    
    public class Folder
    {
        public string path;

    }
}