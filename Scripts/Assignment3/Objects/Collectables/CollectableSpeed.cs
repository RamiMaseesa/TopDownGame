﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects.Collectables
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
