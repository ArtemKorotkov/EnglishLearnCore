using System;
using Lean.Gui;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.MainScen
{
    public class DownMenuScreen: MonoBehaviour
    {
        public event Action OnClickToDictionary;
        public event Action OnClickToHome;
        public event Action OnClickToSettings;

        public LeanSwitch Switch;
        
        
        private void Start()
        {
            Switch.OnChangedState.AddListener(ChangeState);
        }

        private void ChangeState(int state)
        {
            switch (state)
            {
                case 0 :
                    OnClickToDictionary?.Invoke();
                    break;
                case 1 :
                    OnClickToHome?.Invoke();
                    break;
                case 2 :
                    OnClickToSettings?.Invoke();
                    break;
                
            }
        }

        



    }
}