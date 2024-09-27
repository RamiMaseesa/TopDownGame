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
        private float timer;
        private float timeIdle;
        public ChaseState(EnemyBase enemy, Player player) : base(enemy, player)
        {
            timer = 0f;
            timeIdle = 2f;
        }

        protected internal override void UpdateState()
        {
            float distanceToPlayer = Vector2.Distance(enemy.position, player.position);

            if (distanceToPlayer > enemy.detectionRange)
            {
                timer += enemy.deltaTime;

                Vector2 direction = player.position - enemy.position;
                direction.Normalize();

                enemy.position += direction * enemy.slowedSpeed * enemy.deltaTime;

                if (timer > timeIdle)
                {
                    timer = 0;
                    enemy.ChangeState(enemy.patrol);
                }
                
            }
            else
            {
                Vector2 direction = player.position - enemy.position;
                direction.Normalize();

                enemy.position += direction * enemy.speed * enemy.deltaTime;
            }

        }

    }
}
