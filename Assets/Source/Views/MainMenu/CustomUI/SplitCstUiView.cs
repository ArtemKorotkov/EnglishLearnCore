using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SplitCstUiView : MonoBehaviour, ICstUI
{
    [SerializeField] private RectTransform maxWidthElement;
    [SerializeField] private List<RectTransform> elements;
    [SerializeField] private float pudding;


    [ContextMenu("Apply Now In Inspector")]
    public void Apply()
    {
#if UNITY_EDITOR
        Undo.RecordObject(maxWidthElement,"transforms");
        foreach (var element in elements)
        {
            Undo.RecordObject(element,"transforms");
        }
#endif
        
        var width = maxWidthElement.rect.width / elements.Count;
        foreach (var element in elements)
        {
            var tempSizeDelta = element.sizeDelta;
            tempSizeDelta.x = width - pudding;
            element.sizeDelta = tempSizeDelta;
            LayoutRebuilder.ForceRebuildLayoutImmediate(element);
        }
    }
}