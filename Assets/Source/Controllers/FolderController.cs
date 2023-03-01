using CryoDI;
using Source.Serialization;


namespace Source
{
    public class FolderController : IController
    {
        private Folder _folder1;
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private CreateFolderView CreateFolder { get; set; }


        public void Init()
        {
            AllFolders.OnClickToFolder += WordsFromFolder.DisplayWords;
            AllFolders.window.OnShow += Show;
            CreateFolder.OnCreateFolder += Show;
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