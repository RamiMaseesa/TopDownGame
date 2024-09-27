using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.HelperClass;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies
{
    internal class TankEnemy : EnemyBase
    {
        public TankEnemy(Vector2 position, string[] path, List<GameObject> gameobjects) : base(position, path, gameobjects)
        {

        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            detectionRange = 400;
            speed = 100;
            slowedSpeed = 50;
            color = Color.DarkGray;

        }
    }
}
