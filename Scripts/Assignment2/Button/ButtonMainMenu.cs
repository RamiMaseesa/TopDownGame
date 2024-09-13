using Microsoft.Xna.Framework;

namespace TopDownGame.Scripts.Assignment2.Button
{
    internal class ButtonMainMenu : ButtonBase
    {
        public ButtonMainMenu(Vector2 position, string path, string fontPath, string text, Game1 game1)
            : base(position, path, fontPath, text, game1)
        {

        }

        protected internal override void OnClick()
        {
            game1.GoToMenu();
        }
    }
}
