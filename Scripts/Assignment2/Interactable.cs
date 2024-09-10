using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownGame.Scripts.Assignment2
{
    internal class Interactable : GameObject
    {
        protected internal bool isColliding;
        protected internal Player player;
        protected internal SpriteFont font;

        public string text;
        public int offset;

        private Vector2 textSize;
        private string fontPath;

        public Interactable(Vector2 position, string path, string fontPath) : base(position, path)
        {
            this.fontPath = fontPath;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            isColliding = false;
            text = "E";
            offset = 0;
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
            font = content.Load<SpriteFont>(fontPath);
            textSize = font.MeasureString(text);

        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            kstate = Keyboard.GetState();
            collider = new Rectangle((int)position.X + offset, (int)position.Y + offset, sprite.Width, sprite.Height);
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (isColliding)
            {
                spriteBatch.DrawString(font, text, new Vector2(position.X - textSize.X / 2 + 5, position.Y + 50f), Color.White);
            }
        }

        protected internal virtual bool CheckCollisionWithPlayer(Player player)
        {
            if (collider.Intersects(player.collider))
            {
                isColliding = true;
                return true;
            }

            text = "E";
            isColliding = false;
            return false;
        }
    }
}
