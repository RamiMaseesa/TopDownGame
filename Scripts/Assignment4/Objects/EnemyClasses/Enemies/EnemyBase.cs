using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects.HelperObjects;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies
{
    internal class EnemyBase : GameObject
    {
        protected internal Player player;
        private List<GameObject> gameObjects;
        protected internal IdleState idle;
        protected internal PatrolState patrol;
        protected internal ChaseState chase;
        protected internal EnemyStateBase enemyStateBase;

        public Flag[] flags;

        protected internal string[] paths;
        private Texture2D[] sprites;

        public float detectionRange;
        public float speed;

        public EnemyBase(Vector2 position, string[] paths, List<GameObject> gameObjects) : base(position, paths[0])
        {
            
            this.gameObjects = gameObjects;
            this.paths = paths;
        }

        protected internal virtual void ChangeState(EnemyStateBase enemyState)
        {
            enemyStateBase = enemyState; 
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            flags = new Flag[3];
            Random rnd = new Random();

            for (int i = 0; i < flags.Length; i++)
            {
                float randomX = (float)rnd.NextDouble() * 1920;
                float randomY = (float)rnd.NextDouble() * 1080;

                flags[i] = new Flag(new Vector2(randomX, randomY), "flag");
            }



            for (int i = 0; i < flags.Length;i++)
            {
                flags[i].Initialize(graphics);
            }

            sprites =  new Texture2D[4];



        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(paths[i]);
            }

            for (int i = 0; i < flags.Length; i++)
            {
                flags[i].LoadContent(content, graphics);
            }

            foreach (var obj in gameObjects)
            {
                if (obj is Player player) this.player = player;
            }

            idle = new IdleState(this, player);
            patrol = new PatrolState(this, player);
            chase = new ChaseState(this, player);

            enemyStateBase = patrol;
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);

            for (int i = 0; i < flags.Length; i++)
            {
                flags[i].Update(gameTime, graphics);
            }



            enemyStateBase.UpdateState();

        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < flags.Length; i++)
            {
                flags[i].Draw(spriteBatch);
            }
        }
    }
}
