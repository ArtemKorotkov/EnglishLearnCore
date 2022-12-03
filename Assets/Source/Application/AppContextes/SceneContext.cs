using System;
using UnityEngine;

namespace Source
{
    public abstract class SceneContext: MonoBehaviour

    {
        private void Start()
        {
            Application.Shared.BindContext(this); 
        }
    }
}