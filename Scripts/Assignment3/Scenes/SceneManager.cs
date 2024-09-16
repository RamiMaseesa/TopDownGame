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
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.Objects;
using TopDownGame.Scripts.Assignment3.Button;

namespace TopDownGame.Scripts.Assignment3.Scenes
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

        public SceneManager(GraphicsDeviceManager _graphics) {

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
            scenes.Add(GameStates.TitleScreen, titleScreen);

        }

        public List<GameObject> RetrunCurrentScene(GameStates currentGameState)
        {

            return scenes[currentGameState];
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
