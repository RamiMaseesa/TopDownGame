using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TopDownGame.Scripts.Assignment3.Gate;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.SceneClasses;

namespace TopDownGame.Scripts.Assignment3.Objects
{
    internal class Player : GameObject
    {
        public Sword sword;
        public Shield shield;
        public Bow bow;
        public Texture2D[] sprites;
        public List<GameObject> gameObjects;

        private SceneManager sceneManager;
        private float playerSpeed;
        private string[] paths;
        private KeyboardState privousKstate;

        public Player(Vector2 position, string[] paths, float playerSpeed, List<GameObject> gameObjects, SceneManager sceneManager) : base(position, paths[0])
        {
            this.playerSpeed = playerSpeed;
            this.paths = paths;
            this.gameObjects = gameObjects;
            this.sceneManager = sceneManager;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            sprites = new Texture2D[4];
            depth = 0.5f;
            sword = null;
            shield = null;
            sword = null;
            shield = null;
            bow = null;
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);

            for (int i = 0; i < paths.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(paths[i]);
            }

        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);

            MoveMent(kState, gameTime);
            Collision(gameObjects);

            privousKstate = kState;
        }

        protected internal virtual void CheckToSwitchItems(Interactable inter)
        {
            // if inter is a sword
            if (inter is Sword swordInter)
            {
                // check if picked up new soord
                if (sword != swordInter && sword != null)
                {
                    // reset old sword
                    sword.player = null;
                    sword.offset = 0;
                }

                // add new sword
                sword = swordInter;
                sword.player = this;

            }
            else if (inter is Shield shieldInter)
            {
                if (shield != shieldInter && shield != null)
                {
                    shield.player = null;
                    shield.offset = 0;
                }

                shield = shieldInter;
                shield.player = this;
            }
            else if (inter is Bow bowInter)
            {
                if (bow != bowInter && bow != null)
                {
                    bow.player = null;
                    bow.offset = 0;
                }

                bow = bowInter;
                bow.player = this;
            }
        }

        private void MoveMent(KeyboardState kState, GameTime gameTime)
        {
            Vector2 movement = Vector2.Zero;

            // check which pos the player is going and update the sprites if possible
            if (base.kState.IsKeyDown(Keys.A))
            {
                movement.X -= 1;
                if (paths.Length > 1) sprite = sprites[1];
            }
            if (base.kState.IsKeyDown(Keys.D))
            {
                movement.X += 1;
                if (paths.Length > 1) sprite = sprites[2];
            }
            if (base.kState.IsKeyDown(Keys.W))
            {
                movement.Y -= 1;
                if (paths.Length > 1) sprite = sprites[3];
            }
            if (base.kState.IsKeyDown(Keys.S))
            {
                movement.Y += 1;
                if (paths.Length > 1) sprite = sprites[0];
            }

            // normalize movement
            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }

            // add movement to pos
            position += movement * playerSpeed * deltaTime;
        }

        private void Collision(List<GameObject> gameObjects)
        {

            // Iterate backward to safely remove items
            for (int i = gameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = gameObjects[i];

                if (gameObject is Interactable interactable)
                {
                    // If colliding and 'E' is pressed once, pick up Interactable
                    if (interactable.CheckCollisionWithPlayer(this) && kState.IsKeyDown(Keys.E) && !privousKstate.IsKeyDown(Keys.E))
                    {
                        CheckToSwitchItems(interactable);
                    }
                    // If colliding, 'E' is pressed Interactable is a gate
                    else if (interactable.CheckCollisionWithPlayer(this) && !kState.IsKeyDown(Keys.E) && privousKstate.IsKeyDown(Keys.E) && interactable is GateBase gate)
                    {
                        gate.OnGateEnter();
                        sceneManager.HandlePlayerData();
                    }
                }
            }

        }

    }
}
