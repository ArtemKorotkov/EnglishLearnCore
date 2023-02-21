using System;
using Lean.Gui;
using Source.Serialization;
using UnityEngine;
using UnityEngine.UI;


namespace Source
{
    public class WordButtonView : MonoBehaviour
    {
        [SerializeField] private LeanButton button;
        [SerializeField] private Text foreignValue;
        [SerializeField] private Text nativeValue;
        [SerializeField] private ProgressImage progressImage;
        private Word _displayedWord;
        public event Action<Word> Onclick;
        

        private void Start()
        {
           button.OnClick.AddListener(Click);
        }

        public void DisplayWord(Word word)
        {
            _displayedWord = word;
            foreignValue.text = word.ForeignValue;
            nativeValue.text = word.NativeValue;
            progressImage.SetIcon(word.Progress);
        }

        private void Click()
        {
            Onclick?.Invoke(_displayedWord);
        }
    }
}