using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.HelperClass;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies
{
    internal class NormalEnemy : EnemyBase
    {
        public NormalEnemy(Vector2 position, string[] paths, List<GameObject> gameobjects) : base(position, paths, gameobjects)
        {

        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            detectionRange = 300;
            speed = 250;
            
        }


    }
}
