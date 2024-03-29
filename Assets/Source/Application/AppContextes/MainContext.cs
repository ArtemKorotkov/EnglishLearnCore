﻿using CryoDI;
using Source.MainScen;
using Source.Serialization;
using Source.Services;

namespace Source
{
    public class MainContext : SceneContext
    {
        public CryoContainer ViewContainer;

        protected override void SetupContainer(CryoContainer container)
        {
            container.RegisterSceneObject<NotificationView>("Canvases/Notification", LifeTime.Scene);
            container.RegisterSingleton<IStorage, JsonStorage>();
            container.RegisterSingleton<ScreenChangerService>();
            container.RegisterSceneObject<SearchWordView>("Canvases/SearchWord", LifeTime.Scene);
            container.RegisterSceneObject<MainMenuView>("Canvases/MainMenu", LifeTime.Scene);
            container.RegisterSceneObject<AllFoldersView>("Canvases/AllFolders", LifeTime.Scene);
            container.RegisterSceneObject<WordsFromFolderView>("Canvases/WordsFromFolder", LifeTime.Scene);

            container.RegisterSceneObject<CreatorWordView>("Canvases/CreateWordForCreateFolder","CreateFolder",LifeTime.Scene);
            container.RegisterSceneObject<CreatorWordView>("Canvases/CreateWord", LifeTime.Scene);

            container.RegisterSceneObject<SelectFolderView>("Canvases/SelectFolderForCreateFolder", "CreateFolder",LifeTime.Scene);
            container.RegisterSceneObject<SelectFolderView>("Canvases/SelectFolder", LifeTime.Scene);

            container.RegisterSceneObject<CreatorFolderView>("Canvases/CreateFolder", LifeTime.Scene);
            container.RegisterSceneObject<WordContentView>("Canvases/WordContent", LifeTime.Scene);
            container.RegisterSceneObject<SelectWordsView>("Canvases/SelectWords", LifeTime.Scene);


            ViewContainer = container;
        }
    }
}