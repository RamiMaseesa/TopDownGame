using Microsoft.Xna.Framework;
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
            // update color of back ground
            color = new Color(100, 130, 100, 155);
        }
    }
}
