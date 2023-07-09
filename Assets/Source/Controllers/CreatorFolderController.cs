using System.Linq;
using CryoDI;
using Source.Serialization;

namespace Source
{
    public class CreatorFolderController : IController
    {
        [Dependency] private CreatorFolderView CreatorFolder { get; set; }
        [Dependency] private SelectWordsView SelectWords { get; set; }
        [Dependency("CreateFolder")] private CreatorWordView CreatorWord { get; set; }
        [Dependency("CreateFolder")] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }


        public void Init()
        {
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