using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment3.Objects;
using TopDownGame.Scripts.Assignment3.Button;
using TopDownGame.Scripts.Assignment3.Gate;

namespace TopDownGame.Scripts.Assignment3.HelperClass
{
    internal class SceneManager
    {
        private List<GameObject> titleScreen = new List<GameObject>();
        private List<GameObject> mainMenu = new List<GameObject>();
        private List<GameObject> level1 = new List<GameObject>();
        private List<GameObject> level2 = new List<GameObject>();
        private List<GameObject> level3 = new List<GameObject>();
        private List<GameObject> level4 = new List<GameObject>();
        private List<GameObject> level5 = new List<GameObject>();

        private Dictionary<GameStates, List<GameObject>> scenes;
        private GameStates gameState = GameStates.TitleScreen;
        private Player player;

        public SceneManager(GraphicsDeviceManager _graphics, Game1 game1)
        {
            // title screen
            titleScreen.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            titleScreen.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Start", game1));
            titleScreen.Add(new Sword(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f, _graphics.PreferredBackBufferHeight / 2 + 200), "sword1", "font"));
            titleScreen.Add(new Shield(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            titleScreen.Add(new Sword(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 200, _graphics.PreferredBackBufferHeight / 2 + 200), "sword2", "font"));
            titleScreen.Add(new Shield(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 200, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            titleScreen.Add(new Sword(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 400, _graphics.PreferredBackBufferHeight / 2 + 200), "sword3", "font"));
            titleScreen.Add(new Shield(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 400, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            titleScreen.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 1.2f), "bow", "font", "arrow"));
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 5, _graphics.PreferredBackBufferHeight / 3f), "BasicFont", 1f, Color.White, "W A S D to walk"));
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 1.5f), "BasicFont", 1f, Color.White, "Space to fire bow"));
            titleScreen.Add(new Text(new Vector2(_graphics.PreferredBackBufferWidth / 1.5f + 200, _graphics.PreferredBackBufferHeight / 3), "BasicFont", 1f, Color.White, "E to pick up items"));
            titleScreen.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 5, _graphics.PreferredBackBufferHeight / 2),
                             new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, titleScreen, game1));
            scenes.Add(GameStates.TitleScreen, titleScreen);


            // main menu
            mainMenu.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            mainMenu.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Play", game1));
            mainMenu.Add(new ButtonQuit(new Vector2(_graphics.PreferredBackBufferWidth / 2, 600), "button", "fontSmall", "Quit", game1));
            scenes.Add(GameStates.MainMenu, mainMenu);


            // level 1
            level1.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level1.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", game1));
            level1.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level1.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            level1.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            level1.Add(player = new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level1, game1));
            scenes.Add(GameStates.Level1, level1);


            // level 2
            level2.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level2.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", game1));
            level2.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level2.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level2.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword2", "font"));
            level2.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            scenes.Add(GameStates.Level2, level2);


            // level 3
            level3.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level3.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", game1));
            level3.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level3.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level3.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword3", "font"));
            level3.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            scenes.Add(GameStates.Level3, level3);


            // level 4
            level4.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level4.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", game1));
            level4.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level4.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 10, _graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", game1));
            level4.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
            scenes.Add(GameStates.Level4, level4);


            // level 5
            level5.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level5.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", game1));
            level5.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 10, _graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", game1));
            scenes.Add(GameStates.Level5, level5);
        }

        public List<GameObject> RetrunCurrentScene(GameStates currentGameState)
        {

            return scenes[currentGameState];
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            foreach (GameStates state in Enum.GetValues(typeof(GameStates)))
            {
                for (int j = 0; j > scenes[gameState].Count; j++)
                {
                    scenes[state][j].Initialize(graphics);
                }
            }
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            foreach (GameStates state in Enum.GetValues(typeof(GameStates)))
            {
                for (int j = 0; j > scenes[gameState].Count; j++)
                {
                    scenes[state][j].LoadContent(content, graphics);
                }
            }
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < scenes[gameState].Count; i++)
            {
                scenes[gameState][i].Update(gameTime, graphics);
            }
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < scenes[gameState].Count; i++)
            {
                scenes[gameState][i].Draw(spriteBatch);
            }
        }
    }
}
