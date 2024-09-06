using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Assignment1.Scripts
{
    internal class Player : GameObject
    {
        public Texture2D[] sprites;

        private List<GameObject> gameObjects;
        private float playerSpeed;
        private string[] paths;
        private Sword sword;
        private Shield shield;
        private Bow bow;
        private KeyboardState privousKstate;

        public Player(Vector2 position, string[] paths, float playerSpeed, List<GameObject> gameObjects) : base(position, paths[0])
        {
            this.playerSpeed = playerSpeed;
            this.paths = paths;
            this.gameObjects = gameObjects;
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

            MoveMent(kstate, gameTime);
            Collision(gameObjects, privousKstate);

            privousKstate = kstate;
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
            if (kstate.IsKeyDown(Keys.A))
            {
                movement.X -= 1;
                if (paths.Length > 1) sprite = sprites[1];
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                movement.X += 1;
                if (paths.Length > 1) sprite = sprites[2];
            }
            if (kstate.IsKeyDown(Keys.W))
            {
                movement.Y -= 1;
                if (paths.Length > 1) sprite = sprites[3];
            }
            if (kstate.IsKeyDown(Keys.S))
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

        private void Collision(List<GameObject> gameObjects, KeyboardState privousKstate)
        {
            // loop through all game objects
            foreach (GameObject gameObject in gameObjects)
            {
                // check collision from all objects that inherit from Interactable
                if (gameObject is Interactable interactable)
                {
                    // if colliding and E is pressed once pick up Interactable
                    if (interactable.CheckCollisionWithPlayer(this) && kstate.IsKeyDown(Keys.E) && !privousKstate.IsKeyDown(Keys.E))
                    {
                        CheckToSwitchItems(interactable);
                    }
                    // if colliding, E is pressed Interactable is a gate
                    else if (interactable.CheckCollisionWithPlayer(this) && kstate.IsKeyDown(Keys.E) && interactable is Gate gate)
                    {
                        gate.EndGame();
                    }
                }
            }
        }

    }
}
