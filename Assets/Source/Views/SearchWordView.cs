using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source

{
    public class SearchWordView : MonoBehaviour
    {
        public Window window;
        
        [SerializeField] private Button setWord;

        public event Action OnClickToSetWord;

        private void Start()
        {
            setWord?.onClick.AddListener(ClickToSetWord);
        }

        private void ClickToSetWord()
        {
            OnClickToSetWord?.Invoke();
        }
    }
}