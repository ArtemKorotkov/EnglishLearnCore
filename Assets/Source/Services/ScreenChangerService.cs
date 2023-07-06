using System;

namespace Source.Services
{
    public class ScreenChangerService
    {
        public event Action<Type,bool> OnSetState;
        public event Action OnSetPreviousState;
        
        public void SetScreen(Type t, bool setPrevious = true)
        {
            OnSetState?.Invoke(t, setPrevious);  
        }
        public void SetPreviousScreen()
        {
            OnSetPreviousState?.Invoke();  
        }

    }
}