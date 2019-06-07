﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public class TexturePack
    {
        public Texture2D cannonForce;
        public Texture2D droneCarrierForce;
        public Texture2D explosiveForce;
        public Texture2D rocketForce;
        public Texture2D rifleForce;

        public TexturePack(Game game)
        {
            cannonForce = game.Content.Load<Texture2D>("dziala");
            droneCarrierForce = game.Content.Load<Texture2D>("drony");
            explosiveForce = game.Content.Load<Texture2D>("wybuchowy");
            rocketForce = game.Content.Load<Texture2D>("rakiety");
            rifleForce = game.Content.Load<Texture2D>("karabin");

        }
    }

}
