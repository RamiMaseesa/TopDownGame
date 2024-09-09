using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Scripts.Assignment1
{
    internal class Arrow : GameObject
    {
        private Player Player;
        private Vector2 moveDir;
        private float arrowSpeed;
        public Arrow(string path, Player player) : base(player.position, path)
        {
            Player = player;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            arrowSpeed = 500f;

            if (Player.sprite == Player.sprites[1])
            {
                rotation = MathHelper.ToRadians(90);
                moveDir = new Vector2(-1, 0);
            }
            else if (Player.sprite == Player.sprites[2])
            {
                rotation = MathHelper.ToRadians(-90);
                moveDir = new Vector2(1, 0);
            }
            else if (Player.sprite == Player.sprites[3])
            {
                rotation = MathHelper.ToRadians(180);
                moveDir = new Vector2(0, -1);
            }
            else
            {
                moveDir = new Vector2(0, 1);
            }
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);
            HandleArrowMovement();
        }

        private void HandleArrowMovement()
        {
            position += moveDir * arrowSpeed * deltaTime;
        }

        private void HandleOutOfBounds()
        {
            if (position.Y < 0 || position.X < 0 || position.Y > 1920 || position.X < 1080)
            {

            }
        }
    }
}
