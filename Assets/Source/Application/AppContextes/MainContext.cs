using CryoDI;
using Source.MainScen;
using Source.Serialization;

namespace Source
{
    public class MainContext : SceneContext
    {
        public CryoContainer ViewContainer;

        protected override void SetupContainer(CryoContainer container)
        {
            container.RegisterSingleton<IStorage, JsonStorage>();

            container.RegisterSceneObject<SearchWordView>("Canvases/SearchWord", LifeTime.Scene);
            container.RegisterSceneObject<MainMenuView>("Canvases/MainMenu", LifeTime.Scene);
            container.RegisterSceneObject<SetWordView>("Canvases/SetWord", LifeTime.Scene);
            container.RegisterSceneObject<AllFoldersView>("Canvases/AllFolders", LifeTime.Scene);
            container.RegisterSceneObject<WordsFromFolderView>("Canvases/WordsFromFolder", LifeTime.Scene);
            container.RegisterSceneObject<CreateFolderView>("Canvases/CreateFolder", LifeTime.Scene);
            container.RegisterSceneObject<NotificationView>("Canvases/Notification", LifeTime.Scene);
            

            ViewContainer = container;
        }
    }
}