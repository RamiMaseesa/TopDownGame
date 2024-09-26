using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.Button;
using TopDownGame.Scripts.Assignment4.Gate;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects;
using TopDownGame.Scripts.Assignment4.Objects.Collectables;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.SceneClasses.Scenes
{
    internal class Level5Scene : SceneBase
    {
        public Level5Scene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(gWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));

            gameObjects.Add(new Enemy(new Vector2(gWidth / 2, gHeight / 1.5f), new string[] { "enemy", "enemyLeft", "enemyRight", "enemyBack" }, 300f));
            gameObjects.Add(new Enemy(new Vector2(gWidth / 2, gHeight / 2), new string[] { "enemy", "enemyLeft", "enemyRight", "enemyBack" }, 300f));
            gameObjects.Add(new Enemy(new Vector2(gWidth / 2, gHeight / 3), new string[] { "enemy", "enemyLeft", "enemyRight", "enemyBack" }, 300f));

            gameObjects.Add(new CollectableHeart(new Vector2(gWidth / 1.5f, gHeight / 1.5f), "heart", gameObjects));
            gameObjects.Add(new CollectableHeart(new Vector2(gWidth / 1.5f, gHeight / 2), "heart", gameObjects));
            gameObjects.Add(new CollectableHeart(new Vector2(gWidth / 1.5f, gHeight / 3), "heart", gameObjects));

            gameObjects.Add(new GatePreviousScene(new Vector2(gWidth / 10, gHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(gWidth / 1.1f, gHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
        }

        public override void OnSceneEnter()
        {

        }

        public override void OnSceneExit()
        {

        }
    }
}
