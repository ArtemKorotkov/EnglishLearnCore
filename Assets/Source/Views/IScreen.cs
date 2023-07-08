using System;

namespace Source
{
    public interface IScreen
    {
        public event Action OnClickToBack;
        public bool IsShown { get; }
        public void Hide();
        public void Show();

        public void Activate();
    }
}