using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using TopDownGame.Scripts.Assignment3.Objects;
using TopDownGame.Scripts.Assignment3.Button;
using TopDownGame.Scripts.Assignment3.Gate;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.SceneClasses
{
    internal class SceneManager
    {
        private List<GameObject> loseScreen = new List<GameObject>();
        private List<GameObject> titleScreen = new List<GameObject>();
        private List<GameObject> mainMenu = new List<GameObject>();
        private List<GameObject> level1 = new List<GameObject>();
        private List<GameObject> level2 = new List<GameObject>();
        private List<GameObject> level3 = new List<GameObject>();
        private List<GameObject> level4 = new List<GameObject>();
        private List<GameObject> level5 = new List<GameObject>();
        private List<GameObject> winScreen = new List<GameObject>();


        public Dictionary<int, List<GameObject>> scenes;
        public GameStates gameState = GameStates.TitleScreen;

        private Player player;
        private Game1 game1;

        public SceneManager(GraphicsDeviceManager _graphics, Game1 game1)
        {
            scenes = new Dictionary<int, List<GameObject>>();

            this.game1 = game1;

            // lose screen
            loseScreen.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            scenes.Add((int)GameStates.LoseScreen, loseScreen);


            // title screen
            titleScreen.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            titleScreen.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Start", this));
            
            titleScreen.Add(new Sword(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f, _graphics.PreferredBackBufferHeight / 2 + 200), "sword1", "font"));
            titleScreen.Add(new Shield(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            titleScreen.Add(new Sword(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 200, _graphics.PreferredBackBufferHeight / 2 + 200), "sword2", "font"));
            titleScreen.Add(new Shield(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 200, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            titleScreen.Add(new Sword(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 400, _graphics.PreferredBackBufferHeight / 2 + 200), "sword3", "font"));
            titleScreen.Add(new Shield(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 400, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            titleScreen.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 1.2f), "bow", "font", "arrow"));
            titleScreen.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f, _graphics.PreferredBackBufferHeight / 4), new string[] { "gateclosed", "gateopen" }, "font", this));
            titleScreen.Add(new Enemy(new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 4), new string[] { "enemy", "enemyLeft", "enemyRight", "enemyBack" }, 300f));
            
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 30), "BasicFont", 1f, Color.White, "Kill all bad guys to open gate"));
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 5, _graphics.PreferredBackBufferHeight / 3), "BasicFont", 1f, Color.White, "W A S D to walk"));
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 1.5f), "BasicFont", 1f, Color.White, "Space to fire bow"));
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 200, _graphics.PreferredBackBufferHeight / 3), "BasicFont", 1f, Color.White, "E to pick up items"));
            titleScreen.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 5, _graphics.PreferredBackBufferHeight / 2),
                             new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, titleScreen, this));
            scenes.Add((int)GameStates.TitleScreen, titleScreen);


            // main menu
            mainMenu.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            mainMenu.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Play", this));
            mainMenu.Add(new ButtonQuit(new Vector2(_graphics.PreferredBackBufferWidth / 2, 600), "button", "fontSmall", "Quit", this));
            scenes.Add((int)GameStates.MainMenu, mainMenu);


            // level 1
            level1.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level1.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level1.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level1.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            level1.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            level1.Add(player = new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level1, this));
            scenes.Add((int)GameStates.Level1, level1);


            // level 2
            level2.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level2.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level2.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level2.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", this));
            level2.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword2", "font"));
            level2.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            scenes.Add((int)GameStates.Level2, level2);


            // level 3
            level3.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level3.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level3.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", this));
            level3.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level3.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword3", "font"));
            level3.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            scenes.Add((int)GameStates.Level3, level3);


            // level 4
            level4.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level4.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level4.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level4.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 10, _graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", this));
            level4.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
            scenes.Add((int)GameStates.Level4, level4);


            // level 5
            level5.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level5.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level5.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 10, _graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", this));
            scenes.Add((int)GameStates.Level5, level5);


            // win Screen
            winScreen.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            scenes.Add((int)GameStates.WinScreen, winScreen);
        }

        public List<GameObject> RetrunCurrentScene(GameStates currentGameState)
        {

            return scenes[(int)currentGameState];
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            // loop through all states
            foreach (GameStates state in Enum.GetValues(typeof(GameStates)))
            {
                // loop through all items in current scene
                for (int j = 0; j < scenes[(int)state].Count; j++)
                {
                    scenes[(int)state][j].Initialize(graphics);
                }
            }
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            foreach (GameStates state in Enum.GetValues(typeof(GameStates)))
            {
                for (int j = 0; j < scenes[(int)state].Count; j++)
                {
                    scenes[(int)state][j].LoadContent(content, graphics);
                }
            }
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].Update(gameTime, graphics);
            }
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].Draw(spriteBatch);
            }
        }

        public void NextSceneInList()
        {
            gameState = (GameStates)(((int)gameState + 1) % Enum.GetValues(typeof(GameStates)).Length);
        }

        public void GoToMenu()
        {
            gameState = GameStates.MainMenu;
        }

        public void Quit()
        {
            game1.Exit();
        }

        public void HandlePlayerData()
        {
            if (gameState == GameStates.MainMenu || gameState == GameStates.TitleScreen) return;

            List<GameObject> temporaryList = new List<GameObject>();

            // handle item transistoin
            if (player.sword != null) HandleItemTtransition(player.sword);

            if (player.shield != null) HandleItemTtransition(player.shield);

            if (player.bow != null) HandleItemTtransition(player.bow);


            // handle player transistoin
            if (!scenes[(int)gameState].Contains(player)) scenes[(int)gameState].Add(player);
            player.gameObjects = scenes[(int)gameState];
            if (scenes[(int)gameState - 1].Contains(player)) scenes[(int)gameState - 1].Remove(player);
            if (gameState != GameStates.Level5 && scenes[(int)gameState + 1].Contains(player))
                scenes[(int)gameState + 1].Remove(player);

        }

        public void PreviousSceneInList()
        {
            gameState = (GameStates)(((int)gameState - 1 + Enum.GetValues(typeof(GameStates)).Length) % Enum.GetValues(typeof(GameStates)).Length);
        }

        private void HandleItemTtransition(GameObject gameObject)
        {
            scenes[(int)gameState].Add(gameObject);
            scenes[(int)gameState - 1].Remove(gameObject);
            if (gameState != GameStates.Level5) scenes[(int)gameState + 1].Remove(gameObject);
        }

        public void GoToLoseScreen()
        {
            gameState = GameStates.LoseScreen;
        }
    }
}
