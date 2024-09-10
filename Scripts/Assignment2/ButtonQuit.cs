using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment1;

namespace TopDownGame.Scripts.Assignment2
{
    internal class ButtonQuit : ButtonBase
    {
        public ButtonQuit(Vector2 position, string path, string fontPath, string text, Game1 game1) 
            : base(position, path, fontPath, text, game1)
        {

        }

        protected internal override void OnClick()
        {
            game1.Quit();
        }
    }
}
