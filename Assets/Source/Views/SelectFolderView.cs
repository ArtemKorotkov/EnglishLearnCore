using System;
using System.Collections.Generic;
using CryoDI;
using Source.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace Source
{
    public class SelectFolderView : CryoBehaviour

    {
        [SerializeField] private DisplayFoldersView displayFolders;
        public Window window;

        public UnityEvent<Folder> OnClickToFolder;

        private void Start()
        {
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
    }
}