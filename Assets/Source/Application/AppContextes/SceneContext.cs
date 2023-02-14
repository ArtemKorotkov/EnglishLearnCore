using System;
using CryoDI;
using UnityEngine;

namespace Source
{
    public abstract class SceneContext: UnityStarter

    {
        private void Start()
        {
            Application.Shared.BindContext(this); 
        }
       
    }
}