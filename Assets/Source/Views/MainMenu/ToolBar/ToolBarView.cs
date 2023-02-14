using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class ToolBarView : MonoBehaviour
    {
        public event Action<string> OnClickToElement;

        [SerializeField] private ToolBarElement[] elements;
        [SerializeField] private ToolBarTarget target;
        [SerializeField] private RectTransform layoutGroup;
        

        private ToolBarElement _current;

        private void Start()
        {
            foreach (var element1 in elements)
            {
                element1.OnClick += Switch;
            }
        }

        public void StateByDefault(string gameObjectName)
        {
            //решение бага с юнити
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup);

            var element = elements.Where(obj => obj.name == gameObjectName).ToList();
            Switch(element.First());

            //должно быть выполнено быстро, так позиция определятся в первый раз
            target.transform.position = element[0].transform.position;
        }

        private void Switch(ToolBarElement element)
        {
            OnClickToElement?.Invoke(element.name);

            _current = element;

            target.MoveTo(_current.transform.position);

             foreach (var toolBarElement in elements)
               toolBarElement.DeSelect();


            _current.Select();
        }
    }
}