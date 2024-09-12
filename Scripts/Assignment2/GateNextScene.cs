using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame.Scripts.Assignment2
{
    internal class GateNextScene : GateBase
    {
        public GateNextScene(Vector2 position, string[] paths, string fontPath, Game1 game) : base(position, paths, fontPath, game)
        {
            this.path = paths[0];
        }

        protected internal override void OnGateEnter()
        {
            game1.NextSceneInList();
        }
    }
}
