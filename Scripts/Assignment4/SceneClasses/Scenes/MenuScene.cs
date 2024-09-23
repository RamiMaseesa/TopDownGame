using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.Button;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects;

namespace TopDownGame.Scripts.Assignment4.SceneClasses.Scenes
{
    internal class MenuScene : SceneBase
    {
        public MenuScene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonNextScene(new Vector2(gWidth / 2, 400), "button", "fontSmall", "Play", sceneManager));
            gameObjects.Add(new ButtonQuit(new Vector2(gWidth / 2, 600), "button", "fontSmall", "Quit", sceneManager));
        }

        public override void OnSceneEnter()
        {
                
        }

        public override void OnSceneExit()
        {

        }
    }
}
