using System;
using System.Linq;
using CryoDI;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class SelectFolderView : CryoBehaviour

    {
        [Dependency] private IStorage Storage { get; set; }
        [SerializeField] private DisplayFoldersView displayFolders;
        public Window window;

        public event Action<Folder> OnClickToFolder;
        private void Start()
        {
            window.OnShow += Show;
            displayFolders.OnClickToFolder += ClickToFolder;
        }

        private void DisplayFolders()
        {
            // по умолчанию стоит сортировка по дате
            displayFolders.Display(Storage.AllFolders.OrderByDescending(folder => folder.Date).ToList());
        }

        private void ClickToFolder(Folder folder)
        {
            OnClickToFolder?.Invoke(folder);
        }

        private void Show()
        {
            DisplayFolders();
        }
    }
}