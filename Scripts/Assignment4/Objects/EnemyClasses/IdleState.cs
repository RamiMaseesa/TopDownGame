﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses
{
    internal class IdleState : EnemyStateBase
    {
        private float timer;
        private float timeIdle;

        public IdleState(EnemyBase enemy, Player player) : base(enemy, player)
        {
            timer = 0f;
            timeIdle = 3f;
        }

        protected internal override void UpdateState() {
            timer += enemy.deltaTime;

            if (timer > timeIdle)
            {
                enemy.ChangeState(EnemyState.Patrol);
            }

            // check if player in range
        }

    }
}
