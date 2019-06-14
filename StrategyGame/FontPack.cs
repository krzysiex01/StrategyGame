using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyGame
{
    public class FontPack
    {
        public SpriteFont BasicFont { get; }

        public FontPack(Game game)
        {
            BasicFont = game.Content.Load<SpriteFont>("Fonts/basicFont");
        }
    }
}
