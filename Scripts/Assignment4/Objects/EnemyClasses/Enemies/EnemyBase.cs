using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects.HelperObjects;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies
{
    internal class EnemyBase : GameObject
    {
        protected internal Player player;
        protected internal IdleState idle;
        protected internal PatrolState patrol;
        protected internal ChaseState chase;

        protected internal Dictionary<int, EnemyStateBase> states;
        protected internal Flag[] flags;

        protected internal EnemyState enemyState = EnemyState.Patrol;

        public EnemyBase(Vector2 position, string path, Player player) : base(position, path)
        {
            this.player = player; 
        }

        protected internal virtual void ChangeState(EnemyState enemyState)
        {
            this.enemyState = enemyState;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            flags = new Flag[3];
            Random rnd = new Random();

            for (int i = 0; i < flags.Length; i++)
            {
                flags[i] = new Flag(new Vector2((float)rnd.NextDouble() * 1920, (float)rnd.NextDouble() * 1080), "flag");
            }

            IdleState idle = new IdleState(this, player);
            PatrolState patrol = new PatrolState(this, player);
            ChaseState chase = new ChaseState(this, player);

            states.Add((int)EnemyState.Idle, idle);
            states.Add((int)EnemyState.Patrol, patrol);
            states.Add((int)EnemyState.Chase, chase);
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);

            states[(int)enemyState].UpdateState();

        }
    }
}
