using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses
{
    internal class PatrolState : EnemyStateBase
    {
        public PatrolState(EnemyBase enemy, Player player) : base(enemy, player)
        {

        }

        protected internal override void UpdateState()
        {
            // check if player in range
        }

    }
}
