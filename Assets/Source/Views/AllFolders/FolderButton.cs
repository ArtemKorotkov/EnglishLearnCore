using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class FolderButton : MonoBehaviour
    {
        [SerializeField] private new Text name;
        [SerializeField] private Text countLearned;
        [SerializeField] private ProgressImage progressImage;

        public string Name
        {
            set => name.text = value;
        }

        public string CountLearned
        {
            set => countLearned.text = value;
        }

        public Progress Progress
        {
            set => progressImage.SetIcon(value);
        }
    }
}