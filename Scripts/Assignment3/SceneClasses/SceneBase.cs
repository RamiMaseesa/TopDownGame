using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.SceneClasses
{
    internal class SceneBase
    {
        protected SceneManager sceneManager;
        protected internal List<GameObject> gameObjects;

        public SceneBase(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            gameObjects = new List<GameObject>();
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            CreateObjects(graphics);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Initialize(graphics);
            }
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].LoadContent(content, graphics);
            }
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime, graphics);
            }
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(spriteBatch);
            }
        }


        // these methods will be overridden
        protected internal virtual void CreateObjects(GraphicsDeviceManager graphics)
        {

        }

        protected internal virtual void OnSceneEnter()
        {

        }

        protected internal virtual void OnSceneExit()
        {

        }
    }
}
