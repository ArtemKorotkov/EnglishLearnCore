using Lean.Gui;
using TMPro;
using UnityEngine;

namespace Source
{
    public class ProgressBarCircleView : MonoBehaviour
    {

        [SerializeField] private LeanCircle barCircle;

        [SerializeField] private TextMeshProUGUI txtTitle;
        private float barValue;

        public float BarValue
        {
            get { return barValue; }

            set
            {
                value = Mathf.Clamp(value, 1, 99);
                barValue = value;
                UpdateValue(barValue);
            }
        }
        

        void UpdateValue(float val)
        {
            barCircle.Fill = val / 100;
            txtTitle.text =  val + "%";
        }
    }
}