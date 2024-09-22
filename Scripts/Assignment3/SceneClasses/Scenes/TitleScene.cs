using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment3.Button;
using TopDownGame.Scripts.Assignment3.Gate;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.Objects;
using TopDownGame.Scripts.Assignment3.Objects.Collectables;

namespace TopDownGame.Scripts.Assignment3.SceneClasses.Scenes
{
    internal class TitleScene : SceneBase
    {
        public TitleScene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects()
        {
            gameObjects.Add(new Background(new Vector2(gWidth / 2, gHeight / 2), "Background"));
            gameObjects.Add(new ButtonNextScene(new Vector2(gWidth / 2, 400), "button", "fontSmall", "Start", sceneManager));

            gameObjects.Add(new Sword(new Vector2(gWidth / 1.5f, gHeight / 2 + 200), "sword1", "font"));
            gameObjects.Add(new Shield(new Vector2(gWidth / 1.5f, gHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            gameObjects.Add(new Sword(new Vector2(gWidth / 1.5f + 200, gHeight / 2 + 200), "sword2", "font"));
            gameObjects.Add(new Shield(new Vector2(gWidth / 1.5f + 200, gHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            gameObjects.Add(new Sword(new Vector2(gWidth / 1.5f + 400, gHeight / 2 + 200), "sword3", "font"));
            gameObjects.Add(new Shield(new Vector2(gWidth / 1.5f + 400, gHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            gameObjects.Add(new Bow(new Vector2(gWidth / 2, gHeight / 1.2f), "bow", "font", "arrow"));
            gameObjects.Add(new GateNextScene(new Vector2(gWidth / 1.5f, gHeight / 4), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Enemy(new Vector2(gWidth / 3, gHeight / 4), new string[] { "enemy", "enemyLeft", "enemyRight", "enemyBack" }, 300f));
            gameObjects.Add(new CollectableHeart(new Vector2(400, gHeight / 1.2f), "heart", gameObjects));
            gameObjects.Add(new CollectableSpeed(new Vector2(200, gHeight / 1.2f), "feather", gameObjects));
            gameObjects.Add(new CollectableSpeed(new Vector2(600, gHeight / 1.2f), "feather", gameObjects));

            gameObjects.Add(new Text(new Vector2(400, gHeight / 1.5f), "BasicFont", 1f, Color.White, "These are Collectables"));
            gameObjects.Add(new Text(new Vector2(gWidth / 2, gHeight / 30), "BasicFont", 1f, Color.White, "Kill all bad guys to open gate, also dont touch them!"));
            gameObjects.Add(new Text(new Vector2(gWidth / 5, gHeight / 3), "BasicFont", 1f, Color.White, "W A S D to walk"));
            gameObjects.Add(new Text(new Vector2(gWidth / 2, gHeight / 1.5f), "BasicFont", 1f, Color.White, "Space to fire bow"));
            gameObjects.Add(new Text(new Vector2(gWidth / 1.5f + 200, gHeight / 3), "BasicFont", 1f, Color.White, "E to pick up items"));
            gameObjects.Add(new Player(new Vector2(gWidth / 5, gHeight / 2),
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
