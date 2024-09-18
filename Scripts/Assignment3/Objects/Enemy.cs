using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Enemy : GameObject
    {
        private float enemySpeed;
        private Texture2D[] sprites;
        private string[] paths;
        public Enemy(Vector2 position, string[] paths, float enemySpeed) 
            : base(position, paths[0])
        {
            this.paths = paths;
            this.enemySpeed = enemySpeed;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            sprites = new Texture2D[4];
            depth = 0.5f;
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);

            for (int i = 0; i < paths.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(paths[i]);
            }

        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);

            // add enemy behaviour
        }
    }
}
