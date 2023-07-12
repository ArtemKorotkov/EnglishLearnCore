using CryoDI;
using Source.Serialization;


namespace Source
{
    public class ShowAllFolderController : IController
    {
        [Dependency] private AllFoldersView AllFolders { get; set; }
        [Dependency] private WordsFromFolderView WordsFromFolder { get; set; }
        [Dependency] private WordContentView WordContent { get; set; }
        [Dependency] private IStorage Storage { get; set; }

        public void Init()
        {
            AllFolders.screen.OnShow += DisplayAllFolders;
            AllFolders.OnClickToFolder += DisplayWordFromFolder;
            WordsFromFolder.OnClickToWord += DisplayWordContent;
        }

        private void DisplayAllFolders()
        {
            AllFolders.DisplayFolders(Storage.AllFolders);
        }

        private void DisplayWordFromFolder(Folder folder)
        {
            WordsFromFolder.DisplayWords(folder);
        }

        private void DisplayWordContent(Word word, Folder folder)
        {
            WordContent.Display(word, folder);
        }


        public void Run()
        {
        }
    }
}