using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Text : GameObject
    {

        private SpriteFont font;
        private string fontPath;
        private string text;
        private Vector2 textSize;

        public Text(Vector2 position, string fontPath, float depth, Color color, string text) : base(position, fontPath, depth, color)
        {
            this.position = position;
            this.fontPath = fontPath;
            this.text = text;
            this.depth = depth;
            this.color = color;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {

        }
        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            font = content.Load<SpriteFont>(fontPath);
            textSize = font.MeasureString(text);
        }
        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {

        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, new Vector2(position.X - textSize.X / 2 + 5, position.Y + 50f), color);
        }
    }
}
