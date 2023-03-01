using System;
using UnityEngine;

namespace Source
{
    public class NotificationView : MonoBehaviour
    {
        [SerializeField] private WarningMessageView warning;
        [SerializeField] private GoodMessageView good;

        private void Awake()
        {
            CloseAll();
        }

        private void CloseAll()
        {
            warning.Hide();
            good.Hide();
        }

        public void ShowGood(string message)
        {
            CloseAll();
            good.Show(message);
        }

        public void ShowWarning(string message)
        {
            CloseAll();
            warning.Show(message);
        }
    }
}