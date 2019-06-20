using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class CannonForce : Force
    {
        public CannonForce(TexturePack texturePack, GameTime gameTime)
        {
            Id = ForcesType.Dziala;
            Hp = 200;
            Range = 4;
            Speed = 20;
            Armor = 0.75;
            AtackPoints = 90;
            Accuracy = 0.5;
            Texture = texturePack.cannonForce;
            ReloadTime = 5.0;
            IsReloading = false;
        }
    }
}
