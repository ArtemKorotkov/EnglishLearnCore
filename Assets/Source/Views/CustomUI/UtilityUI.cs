using UnityEngine;

namespace Source
{
    public static class UtilityUI
    {
        public static void SetWidth(RectTransform transform, float width)
        {
            var tempSizeDelta = transform.sizeDelta;
            tempSizeDelta.x = width;
            transform.sizeDelta = tempSizeDelta;
        }

        public static void SetHeight(RectTransform transform, float height)
        {
            var tempSizeDelta = transform.sizeDelta;
            tempSizeDelta.y = height;
            transform.sizeDelta = tempSizeDelta;
        }
    }
}