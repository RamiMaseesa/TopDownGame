using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TopDownGame.Scripts.Assignment3.HelperClass
{
    internal class GameObject
    {
        protected internal string path;
        protected internal float depth;
        protected internal float rotation;
        protected internal float deltaTime;
        protected internal Vector2 position;
        protected internal Rectangle collider;
        protected internal Color color;
        protected internal Texture2D sprite;

        protected KeyboardState kState;
        public GameObject(Vector2 position, string path)
        {
            this.position = position;
            this.path = path;
        }

        public GameObject(Vector2 position, string path, float depth, Color color)
        {
            this.position = position;
            this.path = path;
            this.depth = depth;
            this.color = color;
        }

        protected internal virtual void Initialize(GraphicsDeviceManager graphics)
        {
            depth = 0.0f;
            rotation = 0.0f;
            color = Color.White;
        }
        protected internal virtual void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            sprite = content.Load<Texture2D>(path);
        }
        protected internal virtual void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            kState = Keyboard.GetState();
            collider = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, color, rotation,
            new Vector2(sprite.Width / 2, sprite.Height / 2), new Vector2(1, 1), SpriteEffects.None, depth);
        }
    }
}
