using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TopDownGame.Scripts.Assignment4.HelperClass;

namespace TopDownGame.Scripts.Assignment4.Objects.Collectables
{
    internal class CollectableSpeed : CollectablesBase
    {
        public CollectableSpeed(Vector2 position, string path, List<GameObject> gameObjects) : base(position, path, gameObjects)
        { 
        
        }

        public override void OnCollision(Player player)
        {
            player.playerSpeed += 100;
            gameObjects.Remove(this);
        }
    }
}
