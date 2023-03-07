using System.Linq;
using CryoDI;
using Source.MainScen;
using Source.Serialization;
using Source.Services;


namespace Source
{
    public class FolderController : IController
    {
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private CreatorFolderView CreatorFolder { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }

        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private MainMenuView MainMenu { get; set; }
        [Dependency] private WordContentView WordContent { get; set; }


        public void Init()
        {
            MainMenu.dictFunctions.OnClickToAllFolders += () => ScreenChanger.SetScreen(typeof(AllFoldersView));
            
            AllFolders.window.OnShow += AllFoldersInit;
            AllFolders.OnClickToFolder += (_) => ScreenChanger.SetScreen(typeof(WordsFromFolderView));
            AllFolders.OnClickToFolder += WordsFromFolder.DisplayWords;
            AllFolders.OnClickToCreateFolder += () => ScreenChanger.SetScreen(typeof(CreatorFolderView));


            CreatorFolder.window.OnShow += CreateFolderInit;
            CreatorFolder.OnClickToSelectWordFromFolder += () => ScreenChanger.SetScreen(typeof(SelectFolderView));
            CreatorFolder.OnCreateFolder += CreateFolder;
            CreatorFolder.OnCreateFolder += _ => ScreenChanger.SetPreviousScreen();


            SelectFolder.window.OnShow += SelectFolderInit;
        }


        private void AllFoldersInit()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
            WordsFromFolder.OnClickToWord.RemoveAllListeners();

            WordsFromFolder.OnClickToWord.AddListener((_, _) => ScreenChanger.SetScreen(typeof(WordContentView)));
            WordsFromFolder.OnClickToWord.AddListener( WordContent.Display);
        }

        private void CreateFolderInit()
        {
            var foldersName = Storage.AllFolders.Select(folder => folder.Name).ToList();
            CreatorFolder.SetFoldersName(foldersName);

            SelectFolder.OnClickToFolder.RemoveAllListeners();
            SelectFolder.OnClickToFolder.AddListener(WordsFromFolder.DisplayWords);
            SelectFolder.OnClickToFolder.AddListener((_) => ScreenChanger.SetScreen(typeof(WordsFromFolderView)));

            WordsFromFolder.OnClickToWord.RemoveAllListeners();
            WordsFromFolder.OnClickToWord.AddListener((word, _) => CreatorFolder.AddWord(word));
            WordsFromFolder.OnClickToWord.AddListener((_, _) => ScreenChanger.SetScreen(typeof(CreatorFolderView), false));
        }

        public void Run()
        {
        }


        private void CreateFolder(Folder folder)
        {
            Storage.SaveFolder(folder);
        }

        private void SelectFolderInit()
        {
            SelectFolder.DisplayFolders(Storage.AllFolders);
        }
    }
}