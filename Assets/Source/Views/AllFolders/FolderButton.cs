using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class FolderButton : MonoBehaviour
    {
        [SerializeField] private Text name;
        [SerializeField] private Text progress;
        [SerializeField] private Text countLearned;

        public string Name
        {
            get => name.text;
            set => name.text = value;
        }
        public string Progress
        {
            get => progress.text;
            set => progress.text = value;
        }
        public string CountLearned
        {
            get => countLearned.text;
            set => countLearned.text = value;
        }

    }
}