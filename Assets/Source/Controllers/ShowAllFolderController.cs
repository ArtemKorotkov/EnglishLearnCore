using CryoDI;
using Source.Serialization;


namespace Source
{
    public class ShowAllFolderController : IController
    {
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }

        public void Init()
        {
            AllFolders.screen.OnShow += DisplayAllFolders;
            AllFolders.OnClickToFolder += WordsFromFolder.DisplayWords;
        }

        private void DisplayAllFolders()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
        }

        public void Run()
        {
        }
    }
}