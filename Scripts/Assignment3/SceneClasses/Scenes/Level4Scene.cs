using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.Button;
using TopDownGame.Scripts.Assignment3.Gate;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.Objects;

namespace TopDownGame.Scripts.Assignment3.SceneClasses.Scenes
{
    internal class Level4Scene : SceneBase
    {
        public Level4Scene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(gWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));
            gameObjects.Add(new GatePreviousScene(new Vector2(gWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(gWidth / 10, gHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Bow(new Vector2(gWidth / 2, 800), "bow", "font", "arrow"));
        }

        public override void OnSceneEnter()
        {

        }

        public override void OnSceneExit()
        {

        }
    }
}
