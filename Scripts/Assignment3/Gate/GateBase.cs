using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.SceneClasses;

namespace TopDownGame.Scripts.Assignment3.Gate
{
    internal class GateBase : Interactable
    {
        protected internal SceneManager sceneManager;

        private Texture2D[] sprites;
        private string[] paths;

        public GateBase(Vector2 position, string[] paths, string fontPath, SceneManager sceneManager) : base(position, paths[0], fontPath)
        {
            this.paths = paths;
            this.sceneManager = sceneManager;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            sprites = new Texture2D[2];
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
            // loade all sprites
            for (int i = 0; i < paths.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(paths[i]);
            }
        }

        protected internal virtual void OnGateEnter()
        {

        }

    }
}
