using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoudouLaCrapule.Sources
{
    class Sprite
    {
        protected Texture2D texture;
        public Point Position { get { return destRect.Location; } set { destRect.Location = value; } }
        protected Point size;
        protected Color tint;

        //public virtual Point Position { get { return position; } set { position = value; } }

        public Rectangle destRect;

        public Sprite(Texture2D texture, Point position, Color tint)
        {
            this.texture = texture;
            this.Position = position;
            this.size = new Point(texture.Width, texture.Height);
            this.tint = tint;

            this.destRect = new Rectangle(position, size);
        }

        public Sprite(Texture2D texture, Point position, Point size, Color tint)
        {
            this.texture = texture;
            this.Position = position;
            this.size = size;
            this.tint = tint;

            this.destRect = new Rectangle(position, size);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, Color.White);
        }

    }
}
