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
            container.RegisterSceneObject<AllFoldersView>("Canvases/AllFolders", LifeTime.Scene);
            container.RegisterSceneObject<WordsFromFolderView>("Canvases/WordsFromFolder", LifeTime.Scene);
            container.RegisterSceneObject<CreatorFolderView>("Canvases/CreateFolder", LifeTime.Scene);
            container.RegisterSceneObject<NotificationView>("Canvases/Notification", LifeTime.Scene);
            container.RegisterSceneObject<CreateWordView>("Canvases/CreateWord", LifeTime.Scene);
            container.RegisterSceneObject<SelectFolderView>("Canvases/SelectFolder", LifeTime.Scene);

            ViewContainer = container;
        }
    }
}