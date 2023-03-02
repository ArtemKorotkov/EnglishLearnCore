using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    
    public class SetMaxHeightCstUiView : MonoBehaviour, ICstUI
    {
        [Header("Element that you set Max Height from following elements")] 
        [SerializeField] private RectTransform target;

        [SerializeField] private List<RectTransform> elements;
        [SerializeField] private float indent = 0f;
        

        [ContextMenu("Apply Now In Inspector")]
        public void Apply()
        {
#if UNITY_EDITOR
            Undo.RecordObject(target, "transforms");
            foreach (var element in elements)
            {
                Undo.RecordObject(element, "transforms");
            }
#endif
            var maxHeightElement = elements.OrderByDescending(e => e.rect.height).First();
            UtilityUI.SetHeight(target, maxHeightElement.rect.height + indent);
            LayoutRebuilder.ForceRebuildLayoutImmediate(target);
        }
        
    }
}