using CryoDI;
using Source.MainScen;
using Source.Serialization;
using Source.Services;


namespace Source
{
    public class ShowAllFolderController : IController
    {
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }
        
        public void Init()
        {
            AllFolders.OnClickToCreateFolder += () => ScreenChanger.SetScreen(Screens.CreatorFolder);
            AllFolders.screen.OnShow += DisplayAllFolders;
            AllFolders.OnClickToFolder += _ => ScreenChanger.SetScreen(Screens.WordsFromFolder);
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