using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Source
{
    public class AllFoldersView : MonoBehaviour
    {
        public Window window;
        
        [SerializeField] private Transform content;

        [SerializeField] private FolderButton buttonPrefab;
        
        

        public void DisplayAllFolders(Folder[] folders)
        {
            foreach (var folder in folders)
            {
                FolderButton folderButton = Instantiate(buttonPrefab, content, false);
            }
        }
        
        

    }
}