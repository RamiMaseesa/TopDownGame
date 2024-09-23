using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.Button;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects;

namespace TopDownGame.Scripts.Assignment4.SceneClasses.Scenes
{
    internal class LoseScene : SceneBase
    {
        public LoseScene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new Text(new Vector2(gWidth / 2, gHeight / 5), "largeFont", 1f, Color.Red, "WOMP WOMP YOU LOST!"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(gWidth / 2, gHeight / 2), "button", "fontSmall", "Menu", sceneManager));
        }

        public override void OnSceneEnter()
        {

        }

        public override void OnSceneExit()
        {

        }
    }
}
