using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{

    public static class TexturePack
    {
        public static Texture2D cannonForce;
        public static Texture2D droneCarrierForce;
        public static Texture2D explosiveForce;
        public static Texture2D rocketForce;
        public static Texture2D rifleForce;
        public static Texture2D ButtonFocused;
        public static Texture2D Button;
        public static Texture2D upgradeButton;
        public static Texture2D upgradeButtonFocused;
        public static Texture2D background;
        public static Texture2D smoke;
        public static Texture2D explosion;
        public static GraphicsDevice graphicsDevice;

        //TODO: Texture centering

        public static void TexturePackLoad(Game game)
        {
            cannonForce = game.Content.Load<Texture2D>("dziala");
            droneCarrierForce = game.Content.Load<Texture2D>("drony");
            explosiveForce = game.Content.Load<Texture2D>("wybuchowy");
            rocketForce = game.Content.Load<Texture2D>("rakiety");
            rifleForce = game.Content.Load<Texture2D>("karabin");
            Button = game.Content.Load<Texture2D>("VechicleButton");
            ButtonFocused = game.Content.Load<Texture2D>("VechicleButtonFocused");
            upgradeButton = game.Content.Load<Texture2D>("UpgradeButton");
            upgradeButtonFocused = game.Content.Load<Texture2D>("UpgradeButtonFocused");
            background = game.Content.Load<Texture2D>("desert");
            smoke = game.Content.Load<Texture2D>("SmokeTrail");
            explosion = game.Content.Load<Texture2D>("vehicleExplosion");
            graphicsDevice = game.GraphicsDevice;
        }
    }

}
