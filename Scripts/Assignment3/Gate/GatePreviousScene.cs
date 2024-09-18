using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.SceneClasses;

namespace TopDownGame.Scripts.Assignment3.Gate
{
    internal class GatePreviousScene : GateBase
    {
        public GatePreviousScene(Vector2 position, string[] paths, string fontPath, SceneManager sceneManager) : base(position, paths, fontPath, sceneManager)
        {
            path = paths[1];
        }

        protected internal override void OnGateEnter()
        {
            sceneManager.PreviousSceneInList();
        }
    }
}
