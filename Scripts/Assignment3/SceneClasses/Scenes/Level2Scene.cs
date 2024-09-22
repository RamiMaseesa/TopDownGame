using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.Button;
using TopDownGame.Scripts.Assignment3.Gate;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.Objects;

namespace TopDownGame.Scripts.Assignment3.SceneClasses.Scenes
{
    internal class Level2Scene : SceneBase
    {
        public Level2Scene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(gWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));
            gameObjects.Add(new GatePreviousScene(new Vector2(gWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(gWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Sword(new Vector2(500, gHeight / 2), "sword2", "font"));
            gameObjects.Add(new Shield(new Vector2(1300, gHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
        }

        public override void OnSceneEnter()
        {

        }

        public override void OnSceneExit()
        {

        }
    }
}
