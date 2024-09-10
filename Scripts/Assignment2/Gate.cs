using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownGame.Scripts.Assignment2
{
    internal class Gate : Interactable
    {
        private Texture2D[] sprites;
        private string[] paths;
        private Game1 game1;
        public Gate(Vector2 position, string[] paths, string fontPath, Game1 game) : base(position, paths[0], fontPath)
        {
            this.paths = paths;
            this.game1 = game;
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
            game1.NextSceneInList();
        }

    }
}
