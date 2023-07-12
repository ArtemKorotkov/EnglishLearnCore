using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class ProgressBarCircleView : MonoBehaviour
    {

        [SerializeField] private Image barCircle;

        [SerializeField] private Text txtTitle;
        private float barValue;

        public float BarValue
        {
            get { return barValue; }

            set
            {
                value = Mathf.Clamp(value, 0, 100);
                barValue = value;
                UpdateValue(barValue);
            }
        }
        

        void UpdateValue(float val)
        {
            barCircle.fillAmount = -(val / 100) + 1f;
            txtTitle.text =  val + "%";
        }
    }
}