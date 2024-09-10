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

        private GameStates gameState = GameStates.TitleScreen;
        
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
            titleScreen.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Continue", this));
            scenes.Add(titleScreen);

            // main menu
            mainMenu.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            mainMenu.Add(new ButtonNextScene(new Vector2(_graphics.PreferredBackBufferWidth / 2, 400), "button", "fontSmall", "Play", this));
            mainMenu.Add(new ButtonQuit(new Vector2(_graphics.PreferredBackBufferWidth / 2, 600), "button", "fontSmall", "Quit", this));
            scenes.Add(mainMenu);

            // level 1
            level1.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level1.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level1.Add(new Gate(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level1.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            level1.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            level1.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
            level1.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level1));
            scenes.Add(level1);

            // level 2
            level2.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level2.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level2.Add(new Gate(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level2.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword2", "font"));
            level2.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            level2.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
            level2.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level2));
            scenes.Add(level2);

            // level 3
            level3.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level3.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level3.Add(new Gate(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level3.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            level3.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            level3.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level3));
            scenes.Add(level3);

            // level 4
            level4.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level4.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level4.Add(new Gate(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level4.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level4));
            scenes.Add(level4);

            // level 5
            level5.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));
            level5.Add(new ButtonMainMenu(new Vector2(_graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", this));
            level5.Add(new Gate(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));
            level5.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
            level5.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, level5));
            scenes.Add(level5);
        }

        protected override void Initialize()
        {
            // call initialize for all scripts
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].Initialize(_graphics);
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // call loade content for all scripts
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].LoadContent(Content, _graphics);
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

            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].Initialize(_graphics);
            }
            for (int i = 0; i < scenes[(int)gameState].Count; i++)
            {
                scenes[(int)gameState][i].LoadContent(Content, _graphics);
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
    }
}
