#region

using System.Collections.Generic;
using System.Linq;
using CryoDI;
using Source.Serialization;

#endregion

namespace Source
{
    public class FolderController : IController
    {
        private Folder folder1;
        [Dependency] private DisplayFoldersView DisplayFolders { get; set; }
        [Dependency] private DisplayWordsView DisplayWords { get; set; }
        [Dependency] private IStorage Storage { get; set; }


        public void Init()
        {
            
            DisplayFolders.window.OnShow += Show;
            var folder = new Folder();
            folder.Name = "Слова";
            folder.Progress = Progress.Comleted;
            folder.CountLearned = 0;
            var word = new Word();
            word.Progress = Progress.Repeat;
            word.ForeignValue = "word";
            word.NativeValue = "Слово";
            folder.Words = new List<Word>();
            folder.Words.Add(word);
            
            Storage.SaveFolder(folder);
        }

        public void Run()
        {
        }

        private void Show()
        {
            DisplayFolders.DisplayFolders(Storage.AllFolders);
            DisplayWords.DisplayWords(Storage.AllFolders.First());
        }
    }
}