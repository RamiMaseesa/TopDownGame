using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;

namespace TopDownGame.Scripts.Assignment4.Objects.EnemyClasses
{
    internal class EnemyStateBase
    {
        protected internal EnemyBase enemy;
        protected internal Player Player;

        public EnemyStateBase(EnemyBase enemy, Player player)
        {
            this.enemy = enemy;
            this.Player = player;
        }
    }
}
