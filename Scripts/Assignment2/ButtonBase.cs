using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;

namespace TopDownGame.Scripts.Assignment2
{
    internal class ButtonBase : GameObject
    {
        private string fontPath;
        private string text;

        private ButtonStatus buttonStatus;
        private Vector2 textSize;
        private SpriteFont font;
        public ButtonBase(Vector2 position, string path, string fontPath, string text) : base(position, path)
        {
            this.fontPath = fontPath;
            this.text = text;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            depth = 1f;
            buttonStatus = ButtonStatus.Normal;
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
            font = content.Load<SpriteFont>(fontPath);
            textSize = font.MeasureString(text);
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);

        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(font, text, new Vector2(position.X - textSize.X / 2 + 5, position.Y - 23), Color.WhiteSmoke, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
