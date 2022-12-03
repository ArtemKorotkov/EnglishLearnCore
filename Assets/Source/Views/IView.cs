using System;
using UnityEngine;

namespace Source
{
    public interface IView
    {
        public event Action OnClickToBack;
        public bool IsShowen {get;}
        public void Hide();
        public void Show();
        
       
    }
}