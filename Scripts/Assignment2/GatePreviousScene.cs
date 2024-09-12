using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame.Scripts.Assignment2
{
    internal class GatePreviousScene : GateBase
    {
        public GatePreviousScene(Vector2 position, string[] paths, string fontPath, Game1 game) : base(position, paths, fontPath, game)
        {
            this.path = paths[1];
        }

        protected internal override void OnGateEnter()
        {
            game1.PreviousSceneInList();
        }
    }
}
