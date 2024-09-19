using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Background : GameObject
    {
        public Background(Vector2 position, string path) : base(position, path)
        {

        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            color = new Color(100, 130, 100, 155);
        }
    }
}
