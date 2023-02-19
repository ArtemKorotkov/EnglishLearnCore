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
            Clear();
            foreach (var folder in folders)
            {
                FolderButton folderButton = Instantiate(buttonPrefab, content, false);

                folderButton.Name = folder.Name;
                folderButton.CountLearned = "Выучено: " + folder.CountLearned + " из " + folder.Words?.Count.ToString();
                folderButton.Progress = folder.Progress;
            }
        }
        
        private void Clear()
        {
            var childCount = content.childCount;
            
            for (int i = 0; i < childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }
    }
}