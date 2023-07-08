using System;

namespace Source.Services
{
    public class ScreenChangerService
    {
        public event Action<Screens,bool> OnSetState;
        public event Action OnSetPreviousState;
        
        public void SetScreen(Screens screen, bool setPrevious = true)
        {
            OnSetState?.Invoke(screen, setPrevious);  
        }
        public void SetPreviousScreen()
        {
            OnSetPreviousState?.Invoke();  
        }

    }
}