using System.Collections.Generic;
using Source.Serialization;
using UnityEngine;

namespace Source
{
    public class AllFoldersView : MonoBehaviour
    {

        [SerializeField] private Transform content;
        [SerializeField] private FolderButton buttonPrefab;
        
        public Window window;

        public void DisplayFolders(List<Folder> folders)
        {
            foreach (var folder in folders)
            {
                FolderButton folderButton = Instantiate(buttonPrefab, content, false);
                
                folderButton.Name = folder.Name;
                folderButton.Progress = folder.Progress;
                folderButton.CountLearned = folder.CountLearned;
            }
        }
        
        

    }
}