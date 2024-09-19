using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Enemy : GameObject
    {
        public int enemyHealth;

        private bool hit;
        private float afterHitInterval;
        private float time;
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
            enemyHealth = 3;
            time = 0;
            afterHitInterval = .15f;
            hit = true;
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

            AfterHit();

        }

        public bool OnHit()
        {
            enemyHealth--;

            if (enemyHealth <= 0) return true; 

            color = Color.Red; 
            hit = true;

            return false;
        }

        private void AfterHit()
        {
            if (!hit) return;
            time += deltaTime;

            if (time > afterHitInterval)
            {
                color = Color.White;
                time = 0;
                hit = false;
            }
        }

    }
}
