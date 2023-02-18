#region

using System.Collections.Generic;
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

        private List<Folder> _folders;

        public JsonStorage()
        {
            _directoryPath = UnityEngine.Application.persistentDataPath + DirectoryName;
            _folders = LoadAllFolders(_directoryPath);
        }

        public List<Folder> AllFolders
        {
            get => _folders.ToList();
            private set => _folders = value;
        }

        public void SaveFolder(Folder folder)
        {
            _folders.RemoveAll(f => f.Name == folder.Name);
            _folders.Add(folder);

            var filePath = _directoryPath + "/" + folder.Name + ".Json";
            var jsonData = JsonConvert.SerializeObject(folder);
            File.WriteAllText(filePath, jsonData);
        }

        public void SaveFolders(List<Folder> folders)
        {
            foreach (var folder in folders) SaveFolder(folder);
        }

        public void Update()
        {
            _folders = LoadAllFolders(_directoryPath);
        }


        private List<Folder> LoadAllFolders(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var files = Directory.GetFiles(directoryPath);

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