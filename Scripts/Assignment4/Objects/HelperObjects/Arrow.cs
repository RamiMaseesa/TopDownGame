using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.Objects.HelperObjects
{
    internal class Arrow : GameObject
    {
        private Player player;
        private Vector2 moveDir;
        private float arrowSpeed;
        private Bow bow;
        public Arrow(string path, Player player, Bow bow) : base(player.position, path)
        {
            this.player = player;
            this.bow = bow;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            arrowSpeed = 1500f;

            if (player.sprite == player.sprites[1])
            {
                rotation = MathHelper.ToRadians(90);
                moveDir = new Vector2(-1, 0);
            }
            else if (player.sprite == player.sprites[2])
            {
                rotation = MathHelper.ToRadians(-90);
                moveDir = new Vector2(1, 0);
            }
            else if (player.sprite == player.sprites[3])
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
            CheckIfHitEnemy();
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

        private void CheckIfHitEnemy()
        {
            // loop through all objects 
            foreach (GameObject obj in player.gameObjects)
            {
                // if colliding with enemy do proper actions
                if (obj is Enemy enemy && collider.Intersects(obj.collider))
                {
                    player.gameObjects.Remove(obj);

                    bow.arrows.Remove(this);

                    break;
                }
                else if (obj is EnemyBase enemyBase && collider.Intersects(obj.collider))
                {
                    player.gameObjects.Remove(obj);

                    bow.arrows.Remove(this);

                    break;
                }
            }
        }
    }
}
