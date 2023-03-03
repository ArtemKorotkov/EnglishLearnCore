using System.Linq;
using CryoDI;
using Source.Serialization;


namespace Source
{
    public class FolderController : IController
    {
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private CreatorFolderView CreatorFolder { get; set; }


        public void Init()
        {
            AllFolders.window.OnShow += RefreshAllFolders;
            CreatorFolder.window.OnShow += RefreshCreatorFolder;
            
            AllFolders.OnClickToFolder += WordsFromFolder.DisplayWords;
            CreatorFolder.OnCreateFolder += CreateFolder;
        }

        public void Run()
        {
        }

        private void RefreshAllFolders()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
        }
        private void RefreshCreatorFolder()
        {
            var foldersName = Storage.AllFolders.Select(folder => folder.Name).ToList();
            CreatorFolder.SetFoldersName(foldersName);
        }

        private void CreateFolder(Folder folder)
        {
            Storage.SaveFolder(folder);
        }
    }
}