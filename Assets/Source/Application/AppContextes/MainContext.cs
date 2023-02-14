using System;
using CryoDI;
using Source.MainScen;
using Unity.VisualScripting;
using UnityEngine;

namespace Source
{
    public class MainContext : SceneContext
    {
        public CryoContainer ViewContainer;

        protected override void SetupContainer(CryoContainer container)
        {
            container.RegisterSceneObject<SearchWordView>("Canvases/SearchWord", LifeTime.Scene);
            container.RegisterSceneObject<MainMenuView>("Canvases/MainMenu", LifeTime.Scene);
            container.RegisterSceneObject<SetWordView>("Canvases/SetWord", LifeTime.Scene);
            container.RegisterSceneObject<AllFoldersView>("Canvases/AllFolders", LifeTime.Scene);
            
            ViewContainer = container;
        }
    }
}