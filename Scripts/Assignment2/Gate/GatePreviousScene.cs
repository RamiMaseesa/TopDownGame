using Microsoft.Xna.Framework;

namespace TopDownGame.Scripts.Assignment2.Gate
{
    internal class GatePreviousScene : GateBase
    {
        public GatePreviousScene(Vector2 position, string[] paths, string fontPath, Game1 game) : base(position, paths, fontPath, game)
        {
            path = paths[1];
        }

        protected internal override void OnGateEnter()
        {
            game1.PreviousSceneInList();
        }
    }
}
