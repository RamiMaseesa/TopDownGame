﻿using Microsoft.Xna.Framework;
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
    internal class Level4Scene : SceneBase
    {
        public Level4Scene(SceneManager sceneManager, GameStates gameState) : base(sceneManager, gameState)
        {

        }

        protected internal override void CreateObjects(GraphicsDeviceManager graphics)
        {
            gameObjects.Add(new Background(new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2), "Background"));
            gameObjects.Add(new ButtonMainMenu(new Vector2(graphics.PreferredBackBufferWidth - 80, 50), "button", "fontSmall", "Menu", sceneManager));
            gameObjects.Add(new GatePreviousScene(new Vector2(graphics.PreferredBackBufferWidth / 1.2f, 100), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new GateNextScene(new Vector2(graphics.PreferredBackBufferWidth / 10, graphics.PreferredBackBufferHeight / 2), new string[] { "gateclosed", "gateopen" }, "font", sceneManager));
            gameObjects.Add(new Bow(new Vector2(graphics.PreferredBackBufferWidth / 2, 800), "bow", "font", "arrow"));
        }

        public override void OnSceneEnter()
        {

        }

        public override void OnSceneExit()
        {

        }
    }
}
