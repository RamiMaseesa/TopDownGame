using Assignment1.Scripts;
using Assignment1.Scripts.Assignment1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Assignment1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // list to store all objects
        private List<GameObject> objects = new List<GameObject>();

        public Game1()
        {
            // game settings
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content/Sprites";
            IsMouseVisible = false;

            // create objects and add them to the list
            objects.Add(new Background(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), "Background"));

            objects.Add(new Gate(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100), new string[] { "gateclosed", "gateopen" }, "font", this));

            objects.Add(new Sword(new Vector2(500, _graphics.PreferredBackBufferHeight / 2), "sword1", "font"));
            objects.Add(new Sword(new Vector2(600, _graphics.PreferredBackBufferHeight / 2), "sword2", "font"));
            objects.Add(new Sword(new Vector2(700, _graphics.PreferredBackBufferHeight / 2), "sword3", "font"));
            objects.Add(new Shield(new Vector2(1300, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield1", "shield1back" }, "font"));
            objects.Add(new Shield(new Vector2(1400, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield2", "shield2back" }, "font"));
            objects.Add(new Shield(new Vector2(1500, _graphics.PreferredBackBufferHeight / 2), new string[] { "shield3", "shield3back" }, "font"));
            objects.Add(new Bow(new Vector2(_graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));

            objects.Add(new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                        new string[] { "player", "PlayerLeft", "playerRight", "playerBack" }, 400f, objects));

        }

        protected override void Initialize()
        {
            // call initialize for all scripts
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Initialize(_graphics);
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // call loade content for all scripts
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].LoadContent(Content, _graphics);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // call update for all scripts
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(gameTime, _graphics);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(new Color(25, 128, 25, 128));

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            // call draw for all scripts
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
