using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment3.Objects;
using TopDownGame.Scripts.Assignment3.SceneClasses;

namespace TopDownGame.Scripts.Assignment3.Gate
{
    internal class GateNextScene : GateBase
    {
        private bool noEnemies;
        public GateNextScene(Vector2 position, string[] paths, string fontPath, SceneManager sceneManager) : base(position, paths, fontPath, sceneManager)
        {
            path = paths[0];
        }

        protected internal override void OnGateEnter()
        {
            foreach (var obj in sceneManager.scenes[(int)sceneManager.gameState])
            {
                if (obj is Enemy)
                {
                    noEnemies = false;
                }
            }

            if (noEnemies)
            {
                sceneManager.NextSceneInList();
            }
            
            noEnemies = true;
        }
    }
}
