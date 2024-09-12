using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TopDownGame.Scripts.Assignment2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // list to store all objects
        private List<List<GameObject>> scenes = new List<List<GameObject>>();

        private List<GameObject> titleScreen = new List<GameObject>();
        private List<GameObject> mainMenu = new List<GameObject>();
        private List<GameObject> level1 = new List<GameObject>();
        private List<GameObject> level2 = new List<GameObject>();
        private List<GameObject> level3 = new List<GameObject>();
        private List<GameObject> level4 = new List<GameObject>();
        private List<GameObject> level5 = new List<GameObject>();

        private GameStates gameState = GameStates.Level1;
        private Player player;
        
        public Game1()
        {
            // game settings
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content/Sprites";
            IsMouseVisible = true;

            // create objects and add them to Lists

            // title screen
            titleScreen.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            titleScreen.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Start", this));
            scenes.Add(titleScreen);

            // main menu
            mainMenu.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            mainMenu.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Play", this));
            mainMenu.Add(new ButtonQuit(new Vector2(_graphics.PreferredBackBufferWidth / 2, 600), "button", "fontSmall", "Quit", this));
            scenes.Add(mainMenu);

            // level 1
            level1.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level1.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level1.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level1.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            level1.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            level1.Add(player = new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level1, this));
            scenes.Add(level1);

            // level 2
            level2.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level2.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level2.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level2.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", this));
            level2.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword2", "font"));
            level2.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            scenes.Add(level2);

            // level 3
            level3.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level3.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level3.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 900), new string[] { "gateclosed", "gateopen" }, "font", this));
            level3.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level3.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword3", "font"));
            level3.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            scenes.Add(level3);

            // level 4
            level4.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level4.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level4.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level4.Add(new GateNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 10, _graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", this));
            level4.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
            scenes.Add(level4);

            // level 5
            level5.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level5.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level5.Add(new GatePreviousScene(new Vector2(_graphics.PreferredBackBufferWidth / 10, _graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", this));
            scenes.Add(level5);
        }

        protected override void Initialize()
        {
            // call initialize for all scripts
            for (int i = 0; i < scenes.Count; i++)
            {
                for (int j = 0; j < scenes[i].Count; j++)
                {
                    scenes[i][j].Initialize(_graphics);
                }
                
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // call loade content for all scripts
            for (int i = 0; i < scenes.Count; i++)
            {
                for (int j = 0; j < scenes[i].Count; j++)
                {
                    scenes[i][j].LoadContent(Content, _graphics);
                }

            }
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // call update for all scripts
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].Update(gameTime, _graphics);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            //GraphicsDevice.Clear(new Color(25, 128, 25, 128));

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            // call draw for all scripts
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void NextSceneInList()
        {
            gameState = (GameStates)(((int)gameState + 1) % Enum.GetValues(typeof(GameStates)).Length);

            if (gameState == GameStates.TitleScreen)
            {
                GoToMenu();
                return;
            }
        }

        public void GoToMenu()
        {
            gameState = GameStates.MainMenu;
        }

        public void Quit()
        {
            Exit();
        }

        public void HandlePlayerData()
        {
            if (gameState == GameStates.MainMenu) return;

            List<GameObject> temporaryList = new List<GameObject>();

            if (player.sword != null)
            {
                scenes[(int)gameState].Add(player.sword);
                scenes[(int)gameState - 1].Remove(player.sword);
                if (gameState != GameStates.Level5) scenes[(int)gameState + 1].Remove(player.sword);
            }

            if (player.shield != null)
            {
                scenes[(int)gameState].Add(player.shield);
                scenes[(int)gameState - 1].Remove(player.shield);
                if (gameState != GameStates.Level5)  scenes[(int)gameState + 1].Remove(player.shield);
            }

            if (player.bow != null)
            {
                scenes[(int)gameState].Add(player.bow);
                scenes[(int)gameState - 1].Remove(player.bow);
                if (gameState != GameStates.Level5) scenes[(int)gameState + 1].Remove(player.bow);
            }

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
    }
}
