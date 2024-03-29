﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyGame
{
    public class CannonForce : Force
    {
        public CannonForce(GameTime gameTime)
        {
            Id = ForcesType.CannonForce;
            Hp = ForceParametrsPack.Hp[(int)Id];
            Range = 3;
            Speed = 20;
            Armor = 0.65;
            AtackPoints = 90;
            Accuracy = 0.4;
            Texture = TexturePack.cannonForce;
            ReloadTime = 5.0;
            IsReloading = true;
            GameEventEngine.Add(new GameEventDelayed(() => { IsReloading = false; }, ReloadTime));
        }
    }
}
