using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.HelperClass;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies
{
    internal class EnemyBase : GameObject
    {
        protected internal EnemyState state;
        public EnemyBase(Vector2 position, string path) : base(position, path) 
        { 
        
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            state = EnemyState.Patrol;
        }
    }
}
