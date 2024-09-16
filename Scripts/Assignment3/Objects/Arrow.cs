using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Arrow : GameObject
    {
        private Player Player;
        private Vector2 moveDir;
        private float arrowSpeed;
        private Bow bow;
        public Arrow(string path, Player player, Bow bow) : base(player.position, path)
        {
            Player = player;
            this.bow = bow;
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
            HandleOutOfBounds();
        }

        private void HandleArrowMovement()
        {
            position += moveDir * arrowSpeed * deltaTime;
        }

        private void HandleOutOfBounds()
        {
            if (position.Y < 0 || position.X < 0 || position.Y > 1080 || position.X > 1920)
            {
                bow.arrows.Remove(this);
            }
        }
    }
}
