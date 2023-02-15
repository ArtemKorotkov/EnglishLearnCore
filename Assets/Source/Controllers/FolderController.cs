using CryoDI;

namespace Source
{
    public class FolderController : IController
    {
        [Dependency] private AllFoldersView AllFolders { get; set; }
        private Folder[] folders;

        public void Init()
        {
            AllFolders.window.OnShow += Show;
            folders = new[] { new Folder(), new Folder() };
        }

        private void Show()
        {
            AllFolders.DisplayAllFolders(folders);
        }

        public void Run()
        {
        }
    }

    public class Folder
    {
        
    }
}