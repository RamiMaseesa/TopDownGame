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
        private float timer;
        private float timeIdle;
        protected int flagCounter;

        public PatrolState(EnemyBase enemy, Player player) : base(enemy, player)
        {
            timer = 0f;
            timeIdle = 15;
            flagCounter = 0;
        }

        protected internal override void UpdateState()
        {

            float distanceToPlayer = Vector2.Distance(enemy.position, player.position);

            if (distanceToPlayer <= enemy.detectionRange)
            {
                enemy.ChangeState(enemy.chase);
            }

            timer += enemy.deltaTime;

            if (timer > timeIdle)
            {
                timer = 0f;
                enemy.ChangeState(enemy.idle);

            }

            Vector2 direction = enemy.flags[flagCounter].position - enemy.position;
            direction.Normalize(); // Normalize to get a unit vector (just the direction)

            // Update enemy position to move toward the target
            enemy.position += direction * enemy.speed * enemy.deltaTime;

            float distanceToFlag = Vector2.Distance(enemy.position, enemy.flags[flagCounter].position);
            float closeEnoughDistance = 5f; 

            if (distanceToFlag < closeEnoughDistance)
            {
                flagCounter++;

                if (flagCounter == 3)
                {
                    flagCounter = 0;
                }
            }
        }

    }
}
