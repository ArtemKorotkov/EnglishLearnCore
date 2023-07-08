using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class ProgressImage : MonoBehaviour
    {
        [SerializeField] private RawImage rawImage;
        [SerializeField] private Texture completed;
        [SerializeField] private Color colorCompleted;
        [SerializeField] private Texture inProgress;
        [SerializeField] private Color colorInProgress;
        [SerializeField] private Texture repeat;
        [SerializeField] private Color colorRepeat;

        private void SetCompleted()
        {
            rawImage.texture = completed;
            rawImage.color = colorCompleted;
        }

        private void SetInProgress()
        {
            rawImage.texture = inProgress;
            rawImage.color = colorInProgress;
        }

        private void SetRepeat()
        {
            rawImage.texture = repeat;
            rawImage.color = colorRepeat;
        }

        public void SetIcon(Progress icon)
        {
            switch (icon)
            {
                case Progress.Comleted:
                    SetCompleted();
                    break;
                case Progress.InProgress:
                    SetInProgress();
                    break;
                case Progress.Repeat:
                    SetRepeat();
                    break;
            }
        }
    }
}