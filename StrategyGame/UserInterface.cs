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

    public class UserInterface
    {
        int FocusID { get; set; }
        int NumberOfButtons { get; set; }
        Player Player1 { get; set; }
        Player Player2 { get; set; }
        TexturePack TexturePack { get; set; }

        public UserInterface(Player player1, Player player2, TexturePack texturePack )
        {
            FocusID = 0;
            NumberOfButtons = 2;
            TexturePack = texturePack;
            Player1 = player1;
            Player2 = player2;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right))
            {
                FocusID += 1;

            }
            if (state.IsKeyDown(Keys.Left))
            {
                FocusID -= 1;
            }

            if (FocusID < 0)
            {
                FocusID = NumberOfButtons;
            }
            else if (FocusID >= NumberOfButtons)
            {
                FocusID = FocusID = 0;
            }

            if (state.IsKeyDown(Keys.Enter))
            {
                switch (FocusID)
                {
                    case 0:
                        {
                            Player1.AddForces(new CannonForce(TexturePack));
                            break;
                        }
                    case 1:
                        {
                            Player2.AddForces(new RifleForce(TexturePack));
                            break;
                        }
                    default:
                        break;
                }
                
                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            switch (FocusID)
            {
                case 0:
                    {
                        spriteBatch.Draw(TexturePack.cannonForce, new Vector2(0, 0), new Rectangle(0, 0, TexturePack.cannonForce.Width, TexturePack.cannonForce.Height), Color.Blue, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);
                        spriteBatch.Draw(TexturePack.cannonForce, new Vector2(600, 0), new Rectangle(0, 0, TexturePack.cannonForce.Width, TexturePack.cannonForce.Height), Color.Red, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);

                        
                        break;
                    }
                case 1:
                    {
                        spriteBatch.Draw(TexturePack.cannonForce, new Vector2(0, 0), new Rectangle(0, 0, TexturePack.cannonForce.Width, TexturePack.cannonForce.Height), Color.Red, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);
                        spriteBatch.Draw(TexturePack.cannonForce, new Vector2(600, 0), new Rectangle(0, 0, TexturePack.cannonForce.Width, TexturePack.cannonForce.Height), Color.Blue, 0, new Vector2(0, 0), 0.2f, SpriteEffects.FlipHorizontally, 1);

                        break;
                    }
                default:
                    break;
            }
            
            spriteBatch.End();
        }
    }
}
