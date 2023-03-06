using System;
using System.Collections.Generic;
using System.Linq;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class AllFoldersView : MonoBehaviour
    {
        [SerializeField] private LeanButton createFolder;
        [SerializeField] private DisplayFoldersView displayFolders;
        public Window window;
        public event Action OnClickToCreateFolder;
        public event Action<Folder> OnClickToFolder;
        


        private void Start()
        {
            createFolder.OnClick.AddListener(ClickToCreate);
            displayFolders.OnClickToFolder += ClickToFolder;
        }

        public void DisplayFolders(List<Folder> folders)
        {
            displayFolders.Display(folders);
        }

        private void ClickToFolder(Folder folder)
        {
            OnClickToFolder?.Invoke(folder);
        }

        private void ClickToCreate()
        {
            OnClickToCreateFolder?.Invoke();
        }
    }
}