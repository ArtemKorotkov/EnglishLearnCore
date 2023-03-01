using System.Collections.Generic;
using Source;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SplitCstUiView : MonoBehaviour, ICstUI
{
    [SerializeField] private RectTransform maxWidthElement;
    [SerializeField] private List<RectTransform> elements;
    [SerializeField] private float ident;


    [ContextMenu("Apply Now In Inspector")]
    public void Apply()
    {
#if UNITY_EDITOR
        Undo.RecordObject(maxWidthElement, "transforms");
        foreach (var element in elements)
        {
            Undo.RecordObject(element, "transforms");
        }
#endif
        
        var width = maxWidthElement.rect.width / elements.Count;
        
        foreach (var element in elements)
        {
            UtilityUI.SetWidth(element, width - ident);
            LayoutRebuilder.ForceRebuildLayoutImmediate(element);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(maxWidthElement);
    }
}