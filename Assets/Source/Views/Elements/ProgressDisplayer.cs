using UnityEngine;

namespace Source
{
    public class ProgressDisplayer : MonoBehaviour
    {
        [SerializeField] private RectTransform completed;
        [SerializeField] private RectTransform repeat;
        [SerializeField] private ProgressBarCircleView progressBarCircle;


        private void SetCompleted()
        {
            completed.gameObject.SetActive(true);
            repeat.gameObject.SetActive(false);
            progressBarCircle.gameObject.SetActive(false);
        }

        private void SetRepeat()
        {
            repeat.gameObject.SetActive(true);
            completed.gameObject.SetActive(false);
            progressBarCircle.gameObject.SetActive(false);
        }

        private void SetInProgress(int progress)
        {
            progressBarCircle.BarValue = progress;

            progressBarCircle.gameObject.SetActive(true);
            repeat.gameObject.SetActive(false);
            completed.gameObject.SetActive(false);
        }

        public void Set(ProgressType progressType, int progress)
        {
            switch (progressType)
            {
                case ProgressType.Completed:
                    SetCompleted();
                    break;
                case ProgressType.Repeat:
                    SetRepeat();
                    break;
                case ProgressType.InProgress:
                    SetInProgress(progress);
                    break;
            }
        }
    }
}