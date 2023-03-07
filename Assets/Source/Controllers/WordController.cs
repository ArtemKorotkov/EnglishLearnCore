using System.Linq;
using CryoDI;
using Source.MainScen;
using Source.Serialization;
using Source.Services;

namespace Source
{
    public class WordController : IController

    {
        [Dependency] private MainMenuView MainMenu { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private CreatorWordView CreatorWord { get; set; }
        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }
        [Dependency] private SearchWordView SearchWord { get; set; }


        private Folder _folderByDefault;

        public void Init()
        {
            _folderByDefault = Storage.AllFolders.FirstOrDefault();

            MainMenu.dictFunctions.OnClickToSearchWord += () => ScreenChanger.SetScreen(typeof(SearchWordView));
            MainMenu.dictFunctions.OnClickToAddNewWord += () => ScreenChanger.SetScreen(typeof(CreatorWordView));
            MainMenu.dictFunctions.OnClickToAddNewWord += CreatorWordInit;

            SearchWord.OnClickToCreateWord += () => ScreenChanger.SetScreen(typeof(CreatorWordView));
            

            SelectFolder.OnClickToFolder.AddListener(SetFolderByDefault);
            
            Storage.OnUpdate += () => SetFolderByDefault(Storage.AllFolders.FirstOrDefault());
        }

        public void Run()
        {
        }

        private void SetFolderByDefault(Folder folder)
        {
            _folderByDefault = folder;
        }


        private void CreatorWordInit()
        {
            CreatorWord.SelectFolder(_folderByDefault);

            SelectFolder.OnClickToFolder.RemoveAllListeners();
            SelectFolder.OnClickToFolder.AddListener(CreatorWord.SelectFolder);
            SelectFolder.OnClickToFolder.AddListener(SetFolderByDefault);
            SelectFolder.OnClickToFolder.AddListener((_) => ScreenChanger.SetPreviousScreen());
            
            CreatorWord.OnCreateWord.RemoveAllListeners();
            CreatorWord.OnCreateWord.AddListener( (_, _) => ScreenChanger.SetPreviousScreen());
            CreatorWord.OnCreateWord.AddListener(SaveWord);
            
            CreatorWord.OnClickToSelectFolderButton.AddListener(() => ScreenChanger.SetScreen(typeof(SelectFolderView)));
            
            
        }

        private void SaveWord(Word word, Folder folder)
        {
            folder.Words.Add(word);
            Storage.SaveFolder(folder);
        }
    }
}