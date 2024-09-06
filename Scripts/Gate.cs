using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment1.Scripts
{
    internal class Gate : Interactable
    {
        private Texture2D[] sprites;
        private string[] paths;
        private Game game;
        public Gate(Vector2 position, string[] paths, string fontPath, Game game) : base(position, paths[0], fontPath)
        {
            this.paths = paths;
            this.game = game;
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

        public void EndGame()
        {
            game.Exit();
        }

    }
}
