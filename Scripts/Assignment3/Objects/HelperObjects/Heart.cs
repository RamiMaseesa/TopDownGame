using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects.HelperObjects
{
    internal class Heart : GameObject
    {
        public Heart(Vector2 position, string path) : base(position, path)
        {
            
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            depth = 1f;
        }
    }
}
