using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.HelperClass;
using TopDownGame.Scripts.Assignment4.Objects.EnemyClasses.Enemies;
using TopDownGame.Scripts.Assignment4.SceneClasses;

namespace TopDownGame.Scripts.Assignment4.Gate
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
            noEnemies = true;

            foreach (GameObject obj in sceneManager.scenes[(int)sceneManager.gameState].gameObjects)
            {
                if (obj is Enemy || obj is EnemyBase)
                {
                    noEnemies = false;
                }
            }

            if (noEnemies)
            {
                sceneManager.NextSceneInList();
            }
        }
    }
}
