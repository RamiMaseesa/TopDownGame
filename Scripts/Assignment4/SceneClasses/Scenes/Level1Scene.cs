using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.Button;
using TopDownGame.Scripts.Assignment4.Gate;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.SceneClasses.Scenes
{
    internal class Level1Scene : SceneBase
    {

        public Level1Scene (SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {
            
        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(gWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(gWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Sword(new Vector2(500, gHeight / 2), "sword1", "font", 1));
            gameObjects.Add(new Shield(new Vector2(1300, gHeight / 2), new string[] { "shield1", "shield1back" }, "font", 1));
            gameObjects.Add(new NormalEnemy(new Vector2(gWidth / 2, gHeight / 2), new string[] { "enemy", "enemyLeft", "enemyRight", "enemyBack" }, gameObjects));
            gameObjects.Add(new Player(new Vector2(gWidth / 2, gHeight / 1.2f),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, gameObjects, sceneManager));
        }

        public override void OnSceneEnter()
        {
                
        }

        public override void OnSceneExit()
        {
            
        }
    }
}
