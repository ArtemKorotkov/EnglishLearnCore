using System.Collections.Generic;
using System.Linq;
using CryoDI;
using Source.Serialization;


namespace Source
{
    public class FolderController : IController
    {
        private Folder _folder1;
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private IStorage Storage { get; set; }
        [Dependency] private CreateFolderView CreateFolder { get; set; }


        public void Init()
        {
            AllFolders.window.OnShow += Show;
            var folder = new Folder("ads-as", 1, new List<Word>(), Progress.Repeat);
            folder.Name = "Слова";
            folder.Progress = Progress.Comleted;
            folder.CountLearned = 0;
            var word = new Word();
            word.Progress = Progress.Repeat;
            word.ForeignValue = "word";
            word.NativeValue = "Слово";
            folder.Words = new List<Word>();
            folder.Words.Add(word);

            for (int i = 0; i < 10; i++)
            {
                word.ForeignValue += i;
                var words = folder.Words.ToList();
                words.Add(word);
                folder.Words = words;
                folder.Name += i.ToString();
                Storage.SaveFolder(folder);
            }

            AllFolders.OnClickToFolder += WordsFromFolder.DisplayWords;
            CreateFolder.OnCreateFolder += Show;

        }

        public void Run()
        {
        }
        
        private void Show()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
        }
    }
}