using System.Linq;
using CryoDI;
using Source.Serialization;

namespace Source
{
    public class WordController : IController

    {
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private CreatorWordView CreatorWord { get; set; }
        [Dependency] private SelectFolderView SelectFolder { get; set; }
        [Dependency] private WordContentView WordContent { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        private Folder _folderByDefault;

        public void Init()
        {
            Storage.OnUpdate += Init;
            _folderByDefault = Storage.AllFolders.FirstOrDefault();

            CreatorWord.window.OnShow += RefreshCreatorFolder;
            SelectFolder.window.OnShow += RefreshSelectFolder;
            
            SelectFolder.OnClickToFolder += CreatorWord.SelectFolder;
            SelectFolder.OnClickToFolder += SetFolderByDefault;
            CreatorWord.OnCreateWord += SaveWord;

            WordsFromFolder.OnClickToWord += WordContent.Display;
        }

        public void Run()
        {
        }

        private void SetFolderByDefault(Folder folder)
        {
            _folderByDefault = folder;
        }

        private void RefreshSelectFolder()
        {
            SelectFolder.DisplayFolders(Storage.AllFolders);
        }

        private void RefreshCreatorFolder()
        {
            CreatorWord.SelectFolder(_folderByDefault);
        }

        private void SaveWord(Word word, Folder folder)
        {
            folder.Words.Add(word);
            Storage.SaveFolder(folder);
        }
    }
}