using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class WordButtonView : MonoBehaviour
    {
        [SerializeField] private Text nativeValue;
        [SerializeField] private Text foreignValue;
        [SerializeField] private ProgressImage progressImage;

        public string NativeValue
        {
            set => nativeValue.text = value;
        }

        public string ForeignValue
        {
            set => foreignValue.text = value;
        }

        public Progress Progress
        {
            set => progressImage.SetIcon(value);
        }
    }
}