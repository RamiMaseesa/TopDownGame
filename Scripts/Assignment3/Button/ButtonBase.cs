using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TopDownGame.Scripts.Assignment3.HelperClass;
using TopDownGame.Scripts.Assignment3.SceneClasses;

namespace TopDownGame.Scripts.Assignment3.Button
{
    internal class ButtonBase : GameObject
    {
        protected internal SceneManager sceneManager;
        protected internal ButtonStatus buttonStatus;

        private string fontPath;
        private string text;

        private Vector2 textSize;
        private Rectangle mouseCollider;
        private MouseState mState;
        private MouseState previousMState;
        private SpriteFont font;

        public ButtonBase(Vector2 position, string path, string fontPath, string text, SceneManager sceneManager) : base(position, path)
        {
            this.fontPath = fontPath;
            this.text = text;
            this.sceneManager = sceneManager;
        }

        protected internal override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            depth = .99f;
            buttonStatus = ButtonStatus.Normal;
        }

        protected internal override void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            base.LoadContent(content, graphics);
            font = content.Load<SpriteFont>(fontPath);
            textSize = font.MeasureString(text);
        }

        protected internal override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            base.Update(gameTime, graphics);
            mState = Mouse.GetState();
            mouseCollider = new Rectangle(mState.X + sprite.Width / 2, mState.Y + sprite.Height / 2, 1, 1);

            UpdateButtonColor();
            ChangeButtonState();

            previousMState = mState;
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.DrawString(font, text, new Vector2(position.X - textSize.X / 2 + 5, position.Y - 15), color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        private void UpdateButtonColor()
        {
            // change button color
            if (buttonStatus == ButtonStatus.Normal) color = Color.White;
            else if (buttonStatus == ButtonStatus.Hovered) color = Color.Gray;
            else if (buttonStatus == ButtonStatus.Pressed) color = Color.Black;
        }

        private void ChangeButtonState()
        {

            if (collider.Contains(mouseCollider))
            {
                buttonStatus = ButtonStatus.Hovered;
            }
            else
            {
                buttonStatus = ButtonStatus.Normal;
            }

            // button is clicked if allready hovering and when button is released
            if (buttonStatus == ButtonStatus.Hovered && mState.LeftButton == ButtonState.Released && previousMState.LeftButton == ButtonState.Pressed)
            {
                buttonStatus = ButtonStatus.Pressed;
                OnClick();
            }
        }

        protected internal virtual void OnClick()
        {
            // this will be filled in child buttons
        }
    }
}
