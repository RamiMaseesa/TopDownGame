using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Shield : Interactable
    {
        private Texture2D[] sprites;
        private string[] paths;
        private Vector2 offsetForWhenEquiped;
        public Shield(Vector2 position, string[] paths, string fontPath) : base(position, paths[0], fontPath)
        {
            this.paths = paths;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            sprites = new Texture2D[2];
            offsetForWhenEquiped = new Vector2(0, 10);
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
            for (int i = 0; i < paths.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(paths[i]);
            }
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);
            HandleShieldData();
        }

        private void HandleShieldData()
        {
            if (player == null)
            {
                depth = 0;
                return;
            }

            // change pos, depth and sprite to correct values;
            if (player.sprite == player.sprites[1])
            {
                position = player.position + offsetForWhenEquiped;
                depth = 0.4f;
                if (sprites[1] != null) sprite = sprites[1];
            }
            if (player.sprite == player.sprites[2])
            {
                position = player.position + offsetForWhenEquiped;
                depth = 0.6f;
                sprite = sprites[0];
            }
            if (player.sprite == player.sprites[0])
            {
                position = player.position - new Vector2(45, 0) + offsetForWhenEquiped;
                depth = 0.6f;
                sprite = sprites[0];
            }
            if (player.sprite == player.sprites[3])
            {
                position = player.position + new Vector2(45, 0) + offsetForWhenEquiped;
                depth = 0.4f;
                if (sprites[1] != null) sprite = sprites[1];
            }
            text = "";
            offset = 2000;
        }
    }
}
