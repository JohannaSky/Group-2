using Microsoft.Xna.Framework;

namespace Project_X
{
    class Constants
    {
        static public Vector2 screenSize = new Vector2(1430, 1080);
        static public Vector2 scale = new Vector2(50, -50);

        static public Vector2 positionToPixel(Vector2 vector)
        {
            Vector2 temporaryPosition = new Vector2(vector.X * scale.X, vector.Y * scale.Y + screenSize.Y);
            return temporaryPosition;
        }
    }
}
