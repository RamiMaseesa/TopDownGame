using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.SceneClasses;

namespace TopDownGame.Scripts.Assignment3.Gate
{
    internal class GateNextScene : GateBase
    {
        public GateNextScene(Vector2 position, string[] paths, string fontPath, SceneManager sceneManager) : base(position, paths, fontPath, sceneManager)
        {
            path = paths[0];
        }

        protected internal override void OnGateEnter()
        {
            sceneManager.NextSceneInList();
        }
    }
}
