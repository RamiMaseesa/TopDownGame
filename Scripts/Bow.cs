﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Assignment1.Scripts
{
    internal class Bow : Interactable
    {
        private string arrowPath;
        private List<Arrow> arrows;
        private ContentManager content;
        private KeyboardState previousKState;
        public Bow(Vector2 position, string path, string fontPath, string arrowPath) : base(position, path, fontPath)
        {
            this.arrowPath = arrowPath;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            arrows = new List<Arrow>();
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
            this.content = content;
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);

            HandleBowData();
            FireArrows(graphics, content);
            previousKState = kstate;

            for (int i = 0; i < arrows.Count; i++)
            {
                arrows[i].Update(gameTime, graphics);
            }
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < arrows.Count; i++)
            {
                arrows[i].Draw(spriteBatch);
            }
        }

        private void HandleBowData()
        {
            if (player == null)
            {
                depth = 0;
                return;
            }

            // change pos, depth and sprite to correct values;
            if (player.sprite == player.sprites[3])
            {
                position = player.position;
                depth = 0.6f;
            }
            else
            {
                position = player.position;
                depth = 0.4f;
            }

            text = "";
            offset = 2000;
        }

        private void FireArrows(GraphicsDeviceManager graphics, ContentManager content)
        {
            if (player == null) return;

            // only shoot arrows if player is not null and space is pressed once
            if (kstate.IsKeyDown(Keys.Space) && previousKState != kstate)
            {
                Arrow newArrow;
                arrows.Add(newArrow = new Arrow(arrowPath, player));
                newArrow.Initialize(graphics);
                newArrow.LoadContent(content, graphics);
            }
        }
    }
}
