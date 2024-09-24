﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses
{
    internal class IdleState : EnemyStateBase
    {
        public IdleState(EnemyBase enemy, Player player) : base(enemy, player)
        {

        }
    }
}
