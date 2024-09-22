using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using TopDownGame.Scripts.Assignment3.Objects;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.SceneClasses.Scenes;

namespace TopDownGame.Scripts.Assignment3.SceneClasses
{
    internal class SceneManager
    {

        public Dictionary<int, SceneBase> scenes;
        public GameStates gameState = GameStates.TitleScreen;

        private Game1 game1;
        private bool isGoingforward;

        public SceneManager(GraphicsDeviceManager _graphics, Game1 game1)
        {
            scenes = new Dictionary<int, SceneBase>();

            this.game1 = game1;

            // lose screen
            scenes.Add((int)GameStates.LoseScreen, new LoseScene(this, gameState));

            // title screen
            scenes.Add((int)GameStates.TitleScreen, new TitleScene(this, gameState));

            // main menu
            scenes.Add((int)GameStates.MainMenu, new MenuScene(this, gameState));

            // level 1
            scenes.Add((int)GameStates.Level1, new Level1Scene(this, gameState));

            // level 2
            scenes.Add((int)GameStates.Level2, new Level2Scene(this, gameState));

            // level 3
            scenes.Add((int)GameStates.Level3, new Level3Scene(this, gameState));

            // level 4
            scenes.Add((int)GameStates.Level4, new Level4Scene(this, gameState));

            // level 5
            scenes.Add((int)GameStates.Level5, new Level5Scene(this, gameState));

            // win Screen
            scenes.Add((int)GameStates.WinScreen, new WinScene(this, gameState));
        }


        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].Initialize(graphics);
            }
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].LoadContent(content, graphics);
            }
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            scenes[(int)gameState].Update(gameTime, graphics);
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            scenes[(int)gameState].Draw(spriteBatch);
        }

        public void NextSceneInList()
        {
            gameState = (GameStates)(((int)gameState + 1) % Enum.GetValues(typeof(GameStates)).Length);
            isGoingforward = true;
        }

        public void GoToMenu()
        {
            foreach (var obj in scenes[(int)gameState].gameObjects)
            {
                if (obj is Player player)
                {
                    // handle item transistoin
                    if (player.sword != null)
                    {
                        scenes[(int)GameStates.Level1].gameObjects.Add(player.sword);
                        scenes[(int)gameState].gameObjects.Remove(player.sword);
                    }

                    if (player.shield != null)
                    {
                        scenes[(int)GameStates.Level1].gameObjects.Add(player.shield);
                        scenes[(int)gameState].gameObjects.Remove(player.shield);
                    }

                    if (player.bow != null)
                    {
                        scenes[(int)GameStates.Level1].gameObjects.Add(player.bow);
                        scenes[(int)gameState].gameObjects.Remove(player.bow);
                    }

                    player.gameObjects = scenes[(int)GameStates.Level1].gameObjects;
                    scenes[(int)GameStates.Level1].gameObjects.Add(player);
                    scenes[(int)gameState].gameObjects.Remove(player);

                    break;
                }
            }

            gameState = GameStates.MainMenu;
        }

        public void Quit()
        {
            game1.Exit();
        }

        public void HandleSceneData()
        {
            if (gameState == GameStates.MainMenu || gameState == GameStates.TitleScreen) return;

            int num = 1;

            if (!isGoingforward) num = -1;

            foreach (var obj in scenes[(int)gameState - num].gameObjects)
            {
                if (obj is Player player)
                {
                    // handle item transistoin
                    if (player.sword != null) HandleItemTtransition(player.sword);

                    if (player.shield != null) HandleItemTtransition(player.shield);

                    if (player.bow != null) HandleItemTtransition(player.bow);

                    // handle player transistoin
                    if (!scenes[(int)gameState].gameObjects.Contains(player)) scenes[(int)gameState].gameObjects.Add(player);
                    player.gameObjects = scenes[(int)gameState].gameObjects;
                    if (scenes[(int)gameState - 1].gameObjects.Contains(player)) scenes[(int)gameState - 1].gameObjects.Remove(player);
                    if (gameState != GameStates.WinScreen && scenes[(int)gameState + 1].gameObjects.Contains(player))
                        scenes[(int)gameState + 1].gameObjects.Remove(player);

                    break;
                }

            }

            //// handle item transistoin
            //if (player.sword != null) HandleItemTtransition(player.sword);

            //if (player.shield != null) HandleItemTtransition(player.shield);

            //if (player.bow != null) HandleItemTtransition(player.bow);

            //// handle player transistoin
            //if (!scenes[(int)gameState].gameObjects.Contains(player)) scenes[(int)gameState].gameObjects.Add(player);
            //player.gameObjects = scenes[(int)gameState].gameObjects;
            //if (scenes[(int)gameState - 1].gameObjects.Contains(player)) scenes[(int)gameState - 1].gameObjects.Remove(player);
            //if (gameState != GameStates.Level5 && scenes[(int)gameState + 1].gameObjects.Contains(player))
            //    scenes[(int)gameState + 1].gameObjects.Remove(player);

        }

        public void PreviousSceneInList()
        {
            gameState = (GameStates)(((int)gameState - 1 + Enum.GetValues(typeof(GameStates)).Length) % Enum.GetValues(typeof(GameStates)).Length);
            isGoingforward = false;
        }

        private void HandleItemTtransition(GameObject gameObject)
        {
            scenes[(int)gameState].gameObjects.Add(gameObject);
            scenes[(int)gameState - 1].gameObjects.Remove(gameObject);
            if (gameState != GameStates.WinScreen) scenes[(int)gameState + 1].gameObjects.Remove(gameObject);
        }

        public void GoToLoseScreen()
        {
            gameState = GameStates.LoseScreen;
        }
    }
}
