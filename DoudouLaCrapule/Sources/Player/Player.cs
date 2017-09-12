using DoudouLaCrapule.Sources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoudouLaCrapule.Sources.Player
{
    class Player
    {
        private AnimatedSprite animatedSprite;

        private EFacing oldFacing;
        private EFacing facing;
        private bool oldMoving;
        private bool isMoving;

        public Player(AnimatedSprite animatedSprite)
        {
            this.animatedSprite = animatedSprite;

            oldMoving = false;
            isMoving = false;
            oldFacing = EFacing.South;
            facing = EFacing.South;
        }

        public void Update(GameTime gameTime)
        {
            HandleUserInput();

            UpdatePlayerState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animatedSprite.Draw(spriteBatch);
        }

        private void HandleUserInput()
        {
            // Poll for current keyboard state
            KeyboardState state = Keyboard.GetState();

            isMoving = false;

            // Move our sprite based on arrow keys being pressed:
            if (state.IsKeyDown(Keys.Right))
            {
                animatedSprite.Position = animatedSprite.Position + new Point(1,0);
                isMoving = true;
                facing = EFacing.East;
            }   
            if (state.IsKeyDown(Keys.Left))
            {
                animatedSprite.Position = animatedSprite.Position + new Point(-1, 0);
                isMoving = true;
                facing = EFacing.West;
            }
            if (state.IsKeyDown(Keys.Up)) {
                animatedSprite.Position = animatedSprite.Position + new Point(0, -1);
                isMoving = true;
                facing = EFacing.North;
            }
            if (state.IsKeyDown(Keys.Down)) {
                animatedSprite.Position = animatedSprite.Position + new Point(0, 1);
                isMoving = true;
                facing = EFacing.South;
            }
        }

        private void UpdatePlayerState()
        {
            if(isMoving != oldMoving || facing != oldFacing)
            {
                oldMoving = isMoving;
                oldFacing = facing;

                string animationName = "";
                switch (facing)
                {
                    case EFacing.North:
                        animationName = isMoving ? "Walk_Up" : "Idle_Up";
                        break;
                    case EFacing.West:
                        animationName = isMoving ? "Walk_Left" : "Idle_Left";
                        break;
                    case EFacing.East:
                        animationName = isMoving ? "Walk_Right" : "Idle_Right";
                        break;
                    case EFacing.South:
                        animationName = isMoving ? "Walk_Down" : "Idle_Down";
                        break;

                }

                animatedSprite.Play(animationName);
            }
        }
    }
}
