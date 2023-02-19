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
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private IStorage Storage { get; set; }


        public void Init()
        {
            folder1 = new Folder();
           
            
            folder1.Name = "Путешествия";
            folder1.Progress = Progress.Repeat;
            folder1.CountLearned = 1;
            
            
            folder1.Words = new List<Word>();
            for (int i = 0; i < 1000; i++)
            {
                var word = new Word();
                folder1.Words.Add(word);
            }
            Storage.SaveFolder(folder1);

            folder1.Name = "Бизнес";
            folder1.Progress = Progress.Comleted;
            folder1.CountLearned = 2;

            var prev = folder1.Words.ToList();
            folder1.Words = new List<Word>();
            folder1.Words.AddRange(prev);
            for (int i = 0; i < 1000; i++)
            {
                var word = new Word();
                folder1.Words.Add(word);
            }
            Storage.SaveFolder(folder1);
            

            folder1.Name = "Развлечения";
            folder1.Progress = Progress.InProgress;
            folder1.CountLearned = 3;
            
            var prev1 = folder1.Words.ToList();
            folder1.Words = new List<Word>();
            folder1.Words.AddRange(prev1);
            
            for (int i = 0; i < 1000; i++)
            {
                var word = new Word();
                folder1.Words.Add(word);
            }
            Storage.SaveFolder(folder1);

            // var allFolders = Storage.AllFolders;
            //
            // foreach (var folder in allFolders)
            // {
            //     var f = folder;
            //     f.Name += "qqqqqqq";
            //     Storage.SaveFolder(f);
            // }


            AllFolders.window.OnShow += Show;
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