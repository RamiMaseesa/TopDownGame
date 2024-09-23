﻿using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.SceneClasses;

namespace TopDownGame.Scripts.Assignment4.Button
{
    internal class ButtonNextScene : ButtonBase
    {
        public ButtonNextScene(Vector2 position, string path, string fontPath, string text, SceneManager sceneManager)
            : base(position, path, fontPath, text, sceneManager)
        {

        }

        protected internal override void OnClick()
        {
            sceneManager.NextSceneInList();
            sceneManager.HandleSceneData();
        }
    }
}