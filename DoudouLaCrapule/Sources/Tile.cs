using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoudouLaCrapule.Sources
{
    class Tile : Sprite
    {
        private Rectangle sourceRect;

        public Tile(Texture2D texture, Point position, Point size, Rectangle sourceRect, Color tint) : base(texture, position, size, tint)
        {
            this.sourceRect = sourceRect;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destRect, sourceRect, tint);
        }
    }
}
