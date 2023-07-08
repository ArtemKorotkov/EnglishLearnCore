using System.Linq;
using CryoDI;
using Source.Serialization;
using Source.Services;

namespace Source
{
    public class CreatorFolderController : IController
    {
        [Dependency] private CreatorFolderView CreatorFolder { get; set; }
        [Dependency] private SelectWordsView SelectWords { get; set; }
        [Dependency("CreateFolder")] private CreatorWordView CreatorWord { get; set; }
        [Dependency("CreateFolder")] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private ScreenChangerService ScreenChanger { get; set; }


        public void Init()
        {
            CreatorFolder.OnCreateFolder += _ => ScreenChanger.SetScreen(Screens.AllFolders, false);
            CreatorFolder.OnClickToAddNewWord += () => ScreenChanger.SetScreen(Screens.CreatorWordForCreateFolder);
            CreatorFolder.OnClickToSelectWordFromFolder += () => ScreenChanger.SetScreen(Screens.SelectFolderForCreationFolder);
            SelectFolder.OnClickToFolder.AddListener((_) => ScreenChanger.SetScreen(Screens.SelectWords));
            SelectWords.onSelectedWords.AddListener((_) => ScreenChanger.SetScreen(Screens.CreatorFolder, false));
            CreatorWord.OnCreateWord.AddListener((_, _) => ScreenChanger.SetPreviousScreen());

            CreatorFolder.OnCreateFolder += CreateFolder;
            SelectFolder.screen.OnShow += ShowAllFolders;

            SetFoldersName();
            
            SelectWords.onSelectedWords.AddListener(CreatorFolder.AddWords);
            SelectFolder.OnClickToFolder.AddListener(SelectWords.DisplayWords);
            CreatorWord.OnCreateWord.AddListener((word, _) => CreatorFolder.AddWord(word));
            
        }

        private void ShowAllFolders()
        {
            SelectFolder.DisplayFolders(Storage.AllFolders);
        }

        private void CreateFolder(Folder folder)
        {
            Storage.SaveFolder(folder);
        }

        private void SetFoldersName()
        {
            var foldersName = Storage.AllFolders.Select(folder => folder.Name).ToList();
            CreatorFolder.SetFoldersName(foldersName);
        }

        public void Run()
        {
        }
    }
}