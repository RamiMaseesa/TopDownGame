using Microsoft.Xna.Framework;

namespace TopDownGame.Scripts.Assignment2.Gate
{
    internal class GateNextScene : GateBase
    {
        public GateNextScene(Vector2 position, string[] paths, string fontPath, Game1 game) : base(position, paths, fontPath, game)
        {
            path = paths[0];
        }

        protected internal override void OnGateEnter()
        {
            game1.NextSceneInList();
        }
    }
}
