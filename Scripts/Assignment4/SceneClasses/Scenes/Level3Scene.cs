using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.Button;
using TopDownGame.Scripts.Assignment4.Gate;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects;
using TopDownGame.Scripts.Assignment4.Objects.Collectables;

namespace TopDownGame.Scripts.Assignment4.SceneClasses.Scenes
{
    internal class Level3Scene : SceneBase
    {
        public Level3Scene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(gWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));
            gameObjects.Add(new GatePreviousScene(new Vector2(gWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(gWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Sword(new Vector2(500, gHeight / 2), "sword3", "font"));
            gameObjects.Add(new Shield(new Vector2(1300, gHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            gameObjects.Add(new CollectableSpeed(new Vector2(gWidth / 2, gHeight / 2), "feather", gameObjects));
        }

        public override void OnSceneEnter()
        {

        }

        public override void OnSceneExit()
        {

        }
    }
}
