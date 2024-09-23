﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TopDownGame.Scripts.Assignment4.HelperClass;

namespace TopDownGame.Scripts.Assignment4.SceneClasses
{
    internal class SceneBase
    {
        protected SceneManager sceneManager;
        protected GameStates gameState;
        protected internal List<GameObject> gameObjects;
        protected float gWidth;
        protected float gHeight;

        public SceneBase(SceneManager sceneManager, GameStates gameState)
        {
            this.sceneManager = sceneManager;
            this.gameState = gameState;
            gameObjects = new List<GameObject>();
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            gWidth = graphics.PreferredBackBufferWidth;
            gHeight = graphics.PreferredBackBufferHeight;

            CreateObjects();

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
        protected internal virtual void CreateObjects()
        {

        }

        public virtual void OnSceneEnter()
        {

        }

        public virtual void OnSceneExit()
        {

        }
    }
}