﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownGame.Scripts.Assignment3.HelperClass;

namespace TopDownGame.Scripts.Assignment3.Objects.Collectables
{
    internal class CollectablesBase : GameObject
    {
        protected internal List<GameObject> gameObjects;

        public CollectablesBase(Vector2 position, string path, List<GameObject> gameObjects) : base(position, path)
        {
            this.gameObjects = gameObjects;
        }

        public virtual void OnCollision(Player player)
        {
            // will inherit and ovveride
        }
    }
}