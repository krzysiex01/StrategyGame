using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class RifleForce : Force
    {
        public RifleForce(GameTime gameTime)
        {
            Id = ForcesType.RifleForce;
            Hp = ForceParametrsPack.Hp[(int)Id];
            Range = 2;
            Speed = 60;
            Armor = 0.9;
            AtackPoints = 2;
            Accuracy = 0.9;
            Texture = TexturePack.rifleForce;
            ReloadTime = 0.1;
            IsReloading = false;
        }

    }
}
