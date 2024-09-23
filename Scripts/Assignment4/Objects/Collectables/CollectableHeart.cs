using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TopDownGame.Scripts.Assignment4.HelperClass;

namespace TopDownGame.Scripts.Assignment4.Objects.Collectables
{
    internal class CollectableHeart : CollectablesBase
    {
        public CollectableHeart(Vector2 position, string path, List<GameObject> gameObjects) : base(position, path, gameObjects)
        { 
        
        }

        public override void OnCollision(Player player)
        {
            if (player.health == 3) return;

            player.health += 1;
            gameObjects.Remove(this);
        }
    }
}
