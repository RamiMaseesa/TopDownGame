using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses
{
    internal class ChaseState : EnemyStateBase
    {
        public ChaseState(EnemyBase enemy, Player player) : base(enemy, player)
        {

        }

        protected internal override void UpdateState()
        {
            float distanceToPlayer = Vector2.Distance(enemy.position, player.position);

            if (distanceToPlayer > enemy.detectionRange)
            {
                enemy.ChangeState(enemy.patrol);
            }

            Vector2 direction = player.position - enemy.position;
            direction.Normalize();

            enemy.position += direction * enemy.speed * enemy.deltaTime;
        }

    }
}
