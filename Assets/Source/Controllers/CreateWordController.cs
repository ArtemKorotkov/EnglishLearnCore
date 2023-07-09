using System.Linq;
using CryoDI;
using Source.Serialization;

namespace Source
{
    public class WordController : IController

    {
        [Dependency] private CreatorWordView CreatorWord { get; set; }
        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }


        private Folder _folderByDefault;

        public void Init()
        {
            SetFolderByDefault(Storage.AllFolders.FirstOrDefault());
            Storage.OnUpdate += () => SetFolderByDefault(Storage.AllFolders.FirstOrDefault());


            SelectFolder.OnClickToFolder.AddListener(CreatorWord.SelectFolder);
            SelectFolder.OnClickToFolder.AddListener(SetFolderByDefault);
            SelectFolder.screen.OnShow += DisplayAllFolders;

            CreatorWord.screen.OnShow += () => CreatorWord.SelectFolder(_folderByDefault);
            CreatorWord.OnCreateWord.AddListener(SaveWord);
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