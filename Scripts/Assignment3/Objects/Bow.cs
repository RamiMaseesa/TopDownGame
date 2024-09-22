using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.Objects.HelperObjects;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Bow : Interactable
    {
        public List<Arrow> arrows;

        private string arrowPath;
        private ContentManager content;
        private KeyboardState previousKState;

        private float time;
        private float fireInterval;

        public Bow(Vector2 position, string path, string fontPath, string arrowPath) : base(position, path, fontPath)
        {
            this.arrowPath = arrowPath;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            arrows = new List<Arrow>();
            time = 1;
            fireInterval = 1;
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
            previousKState = kState;

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

            // change pos and depth to correct values;
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

            time += deltaTime;

            // only shoot arrows if player is not null and space is pressed once
            if (kState.IsKeyDown(Keys.Space) && previousKState != kState && time > fireInterval)
            {
                Arrow newArrow;
                arrows.Add(newArrow = new Arrow(arrowPath, player, this));
                newArrow.Initialize(graphics);
                newArrow.LoadContent(content, graphics);

                time = 0;
            }
        }
    }
}
