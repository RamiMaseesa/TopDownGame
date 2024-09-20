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

namespace TopDownGame.Scripts.Assignment3.SceneClasses.Scenes
{
    internal class Level1Scene : SceneBase
    {
        private Player player;

        public Level1Scene (SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {
            
        }

        protected internal override void CreateObjects(GraphicsDeviceManager graphics)
        {
            gameObjects.Add(new Background(new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Sword(new Vector2(500, graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            gameObjects.Add(new Shield(new Vector2(1300, graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            gameObjects.Add(player = new Player(new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2),
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
