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
            Speed = 60;
            Armor = 0.9;
            AtackPoints = 2;
            Accuracy = 0.9;
            Texture = texturePack.rifleForce;
            ReloadTime = 0.1;
            IsReloading = false;
        }

    }
}
