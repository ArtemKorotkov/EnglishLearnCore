using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Source.Serialization
{
    public class BinaryStorage
    {
        private string _filePath;
        private BinaryFormatter _formatter;

        public BinaryStorage()
        {
            var saveDirectory = UnityEngine.Application.persistentDataPath + "/saves";

            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);

            _filePath = saveDirectory + "/GameSave.Bin";
            _formatter = new BinaryFormatter();
        }

        public void Save(object saveData)
        {
            var file = File.Create(_filePath);
            _formatter.Serialize(file, saveData);
            file.Close();
        }

        public object Load()
        {
            if (!File.Exists(_filePath))
                return null;
            
            var file = File.Open(_filePath, FileMode.Open);
            var savedData = _formatter.Deserialize(file);
            file.Close();

            return savedData;
        }
    }
}