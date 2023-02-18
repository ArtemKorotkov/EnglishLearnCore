#region

using CryoDI;
using Source.Serialization;

#endregion

namespace Source
{
    public class FolderController : IController
    {
        private Folder folder1;
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private IStorage Storage { get; set; }


        public void Init()
        {
            folder1 = new Folder();
            folder1.Name = "11111";
            folder1.Progress = "11111";
            folder1.CountLearned = "111111";
            Storage.SaveFolder(folder1);

            folder1.Name = "66666";
            folder1.Progress = "666666";
            folder1.CountLearned = "666666";
            Storage.SaveFolder(folder1);

            folder1.Name = "11111";
            folder1.Progress = "qwerty";
            folder1.CountLearned = "qwerty";
            Storage.SaveFolder(folder1);

            var allFolders = Storage.AllFolders;

            foreach (var folder in allFolders)
            {
                var f = folder;
                Storage.SaveFolder(f);
                f.Name += "qqqqqqq";
            }


            AllFolders.window.OnShow += Show;
        }

        public void Run()
        {
        }

        private void Show()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
        }
    }
}