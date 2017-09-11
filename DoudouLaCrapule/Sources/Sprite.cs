using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoudouLaCrapule.Sources
{
    class Sprite
    {
        protected Texture2D texture;
        protected Point position;
        protected Point size;
        protected Color tint;

        private Rectangle rect;

        public void SetPosition(Point newPosition)
        {
            position = newPosition;
        }

        public Sprite(Texture2D texture, Point position, Color tint)
        {
            this.texture = texture;
            this.position = position;
            this.size = new Point(texture.Width, texture.Height);
            this.tint = tint;

            this.rect = new Rectangle(position, size);
        }

        public Sprite(Texture2D texture, Point position, Point size, Color tint)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            this.tint = tint;

            this.rect = new Rectangle(position, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }

    }
}
