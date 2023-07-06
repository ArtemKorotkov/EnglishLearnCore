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
        [Dependency] private CreatorWordView CreatorWord { get; set; }
        [Dependency] private SelectWordsView SelectWords { get; set; }


        public void Init()
        {
            MainMenu.dictFunctions.OnClickToAllFolders += () => ScreenChanger.SetScreen(typeof(AllFoldersView));

            AllFolders.window.OnShow += AllFoldersInit;
            AllFolders.OnClickToFolder += (_) => ScreenChanger.SetScreen(typeof(WordsFromFolderView));
            AllFolders.OnClickToFolder += WordsFromFolder.DisplayWords;
            AllFolders.OnClickToCreateFolder += () => ScreenChanger.SetScreen(typeof(CreatorFolderView));


            CreatorFolder.window.OnShow += CreateFolderInit;
            CreatorFolder.OnClickToSelectWordFromFolder += () => ScreenChanger.SetScreen(typeof(SelectFolderView));
            CreatorFolder.OnClickToAddNewWord += () => ScreenChanger.SetScreen(typeof(CreatorWordView));
            CreatorFolder.OnCreateFolder += CreateFolder;
            CreatorFolder.OnCreateFolder += _ => ScreenChanger.SetScreen(typeof(AllFoldersView), false);


            SelectFolder.window.OnShow += SelectFolderInit;
        }


        private void AllFoldersInit()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
            WordsFromFolder.OnClickToWord.RemoveAllListeners();

            WordsFromFolder.OnClickToWord.AddListener((_, _) => ScreenChanger.SetScreen(typeof(WordContentView)));
            WordsFromFolder.OnClickToWord.AddListener(WordContent.Display);
        }

        private void CreateFolderInit()
        {
            var foldersName = Storage.AllFolders.Select(folder => folder.Name).ToList();
            CreatorFolder.SetFoldersName(foldersName);

            SelectFolder.OnClickToFolder.RemoveAllListeners();
            SelectFolder.OnClickToFolder.AddListener(SelectWords.DisplayWords);
            SelectFolder.OnClickToFolder.AddListener((_) => ScreenChanger.SetScreen(typeof(SelectWordsView)));

            SelectWords.onSelectedWords.RemoveAllListeners();
            SelectWords.onSelectedWords.AddListener(CreatorFolder.AddWords);
            SelectWords.onSelectedWords.AddListener((_) => ScreenChanger.SetScreen(typeof(CreatorFolderView), false));

            CreatorWord.OnCreateWord.RemoveAllListeners();
            CreatorWord.OnClickToSelectFolderButton.RemoveAllListeners();
            var emptyFolder = new Folder();
            emptyFolder.Name = "------";
            CreatorWord.SelectFolder(emptyFolder);
            CreatorWord.OnCreateWord.AddListener((word, _) => CreatorFolder.AddWord(word));
            CreatorWord.OnCreateWord.AddListener((_, _) => ScreenChanger.SetPreviousScreen());
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