using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public class TexturePack
    {
        public Texture2D cannonForce;

        public TexturePack(Game game)
        {
            cannonForce = game.Content.Load<Texture2D>("dziala");
        }
    }

}
