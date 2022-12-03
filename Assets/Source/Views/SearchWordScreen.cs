using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source

{
    public class SearchWordScreen : View
    {
        [SerializeField] private Button SetWord;

        private void Start()
        {
            SetWord?.onClick.AddListener(ClickToSetWord);
        }

        public event Action OnClickToSetWord;

        private void ClickToSetWord()
        {
            OnClickToSetWord?.Invoke();
        }
        
    }
}