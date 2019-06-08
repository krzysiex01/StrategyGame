using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class RifleForce : Force
    {
        public RifleForce(TexturePack texturePack, GameTime gameTime)
        {
            Id = ForcesType.Karabin;
            Hp = 80;
            Range = 3;
            Speed = 50;
            Armor = 0.9;
            AtackPoints = 5;
            Cost = 150;
            Accuracy = 0.9;
            Ammo = 200;
            AmmoMax = 200;
            Texture = texturePack.rifleForce;
            Reload = 0.1;
            LastShot = gameTime.TotalGameTime.TotalSeconds;
        }

    }
}
