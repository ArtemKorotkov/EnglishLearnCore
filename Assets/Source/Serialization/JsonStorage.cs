#region

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

#endregion

namespace Source.Serialization
{
    public class JsonStorage : IStorage
    {
        private const string DirectoryName = "/savesJson";

        private readonly string _directoryPath;


        public JsonStorage()
        {
            _directoryPath = UnityEngine.Application.persistentDataPath + DirectoryName;
        }

        public List<Folder> AllFolders
        {
            get => LoadAllFolders();
        }

        public void SaveFolder(Folder folder)
        {
            var filePath = _directoryPath + "/" + folder.Name + ".Json";
            var jsonData = JsonConvert.SerializeObject(folder);
            File.WriteAllText(filePath, jsonData);
        }

        public void SaveFolders(List<Folder> folders)
        {
            foreach (var folder in folders) SaveFolder(folder);
        }

        private List<Folder> LoadAllFolders()
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            var files = Directory.GetFiles(_directoryPath);

            var allFolders = new List<Folder>();

            foreach (var file in files)
            {
                var folder = JsonConvert.DeserializeObject<Folder>(File.ReadAllText(file));

                var emptyFolder = new Folder();
                if (!folder.Equals(emptyFolder))
                    allFolders.Add(folder);
            }

            
            return allFolders;
        }
    }
}