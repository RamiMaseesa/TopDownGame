using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Sword : Interactable
    {
        public Sword(Vector2 position, string path, string fontPath) : base(position, path, fontPath)
        {

        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);
            HandleSwordData();
        }

        private void HandleSwordData()
        {
            if (player == null)
            {
                depth = 0;
                return;
            }

            // change pos, depth and sprite to correct values;
            if (player.sprite == player.sprites[1])
            {
                position = player.position;
                depth = 0.6f;
            }
            if (player.sprite == player.sprites[2])
            {
                position = player.position;
                depth = 0.4f;
            }
            if (player.sprite == player.sprites[0])
            {
                position = player.position + new Vector2(45, 0);
                depth = 0.6f;
            }
            if (player.sprite == player.sprites[3])
            {
                position = player.position - new Vector2(45, 0);
                depth = 0.4f;
            }
            text = "";
            offset = 2000;
        }
    }
}
