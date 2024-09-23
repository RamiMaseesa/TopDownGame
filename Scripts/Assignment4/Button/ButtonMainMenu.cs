using Microsoft.Xna.Framework;
using TopDownGame.Scripts.Assignment4.SceneClasses;

namespace TopDownGame.Scripts.Assignment4.Button
{
    internal class ButtonMainMenu : ButtonBase
    {
        public ButtonMainMenu(Vector2 position, string path, string fontPath, string text, SceneManager sceneManager)
            : base(position, path, fontPath, text, sceneManager)
        {

        }

        protected internal override void OnClick()
        {
            sceneManager.GoToMenu();
        }
    }
}
