using System.Linq;
using CryoDI;
using Source.Serialization;
using Source.Services;

namespace Source
{
    public class WordController : IController

    {
        [Dependency] private CreatorWordView CreatorWord { get; set; }
        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }


        private Folder _folderByDefault;

        public void Init()
        {
            SetFolderByDefault(Storage.AllFolders.FirstOrDefault());
            Storage.OnUpdate += () => SetFolderByDefault(Storage.AllFolders.FirstOrDefault());


            SelectFolder.OnClickToFolder.AddListener(CreatorWord.SelectFolder);
            SelectFolder.OnClickToFolder.AddListener(SetFolderByDefault);
            SelectFolder.OnClickToFolder.AddListener(_ => ScreenChanger.SetPreviousScreen());
            SelectFolder.screen.OnShow += DisplayAllFolders;

            CreatorWord.screen.OnShow += () => CreatorWord.SelectFolder(_folderByDefault);
            CreatorWord.OnCreateWord.AddListener((_, _) => ScreenChanger.SetPreviousScreen());
            CreatorWord.OnCreateWord.AddListener(SaveWord);
            CreatorWord.OnClickToSelectFolderButton.AddListener(() => ScreenChanger.SetScreen(Screens.SelectFolder));
        }

        private void SetFolderByDefault(Folder folder)
        {
            _folderByDefault = folder;
        }

        private void DisplayAllFolders()
        {
            SelectFolder.DisplayFolders(Storage.AllFolders);
        }

        private void SaveWord(Word word, Folder folder)
        {
            folder.Words.Add(word);
            Storage.SaveFolder(folder);
        }

        public void Run()
        {
        }
    }
}