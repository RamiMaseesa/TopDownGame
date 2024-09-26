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
        protected internal Player player;

        public EnemyStateBase(EnemyBase enemy, Player player)
        {
            this.enemy = enemy;
            this.player = player;
        }

        protected internal virtual void UpdateState() { }
        protected internal virtual void OnStateEnter() { }
        protected internal virtual void OnStateExit() { }
    }
}
