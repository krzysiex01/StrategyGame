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
   

    public class Button
    {
        public ButtonID ButtonId { get; set; }
        Texture2D TextureFocused { get; set; }
        Texture2D TextureBasic { get; set; }
        Texture2D TextureUpgradeBasic { get; set; }
        Texture2D TextureUpgradeFocused { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }

        public Button(int x, int y, Texture2D textureFocused, Texture2D textureBasic, Texture2D textureUpgradeFocused, Texture2D textureUpgradeBasic, ButtonID buttonID)
        {
            PosX = x;
            PosY = y;
            TextureBasic = textureBasic;
            TextureFocused = textureFocused;
            ButtonId = buttonID;
            TextureUpgradeBasic = textureUpgradeBasic;
            TextureUpgradeFocused = textureUpgradeFocused;
        }

        public void DrawBasic(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(TextureBasic, new Vector2(PosX, PosY), new Rectangle(0, 0, TextureBasic.Width, TextureBasic.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            spriteBatch.Draw(TextureUpgradeBasic, new Vector2(PosX, PosY + 103), new Rectangle(0, 0, TextureUpgradeBasic.Width, TextureUpgradeBasic.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            spriteBatch.End();
        }

        public void DrawFocused(SpriteBatch spriteBatch, bool UpgradeFocus)
        {
            spriteBatch.Begin();
            if (UpgradeFocus)
            {
                spriteBatch.Draw(TextureBasic, new Vector2(PosX, PosY), new Rectangle(0, 0, TextureBasic.Width, TextureBasic.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
                spriteBatch.Draw(TextureUpgradeFocused, new Vector2(PosX, PosY + 103), new Rectangle(0, 0, TextureUpgradeFocused.Width, TextureUpgradeFocused.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(TextureFocused, new Vector2(PosX, PosY), new Rectangle(0, 0, TextureFocused.Width, TextureFocused.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
                spriteBatch.Draw(TextureUpgradeBasic, new Vector2(PosX, PosY + 103), new Rectangle(0, 0, TextureUpgradeBasic.Width, TextureUpgradeBasic.Height), Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 1);
            }
            spriteBatch.End();
        }
    }

    public class UserInterface
    {
        int FocusID { get; set; }
        bool UpgradeFocus { get; set; }
        int NumberOfButtons { get; set; }
        Button[] Buttons { get; set; }
        Player Player1 { get; set; }
        Player Player2 { get; set; }
        TexturePack TexturePack { get; set; }
        KeyboardState PrevState { get; set; }

        public UserInterface(Player player1, Player player2, TexturePack texturePack)
        {
            FocusID = 0;
            NumberOfButtons = 5;
            TexturePack = texturePack;
            Player1 = player1;
            Player2 = player2;
            PrevState = Keyboard.GetState();
            Buttons = new Button[5];
            CreateButtons(Buttons);
            UpgradeFocus = false;
        }

        private void CreateButtons(Button[] buttons)
        {
            for (int i = 0; i < NumberOfButtons; i++)
            {
                buttons[i] = new Button(i * 110, 0, TexturePack.explosiveButtonFocused, TexturePack.explosiveButton, TexturePack.upgradeButtonFocused, TexturePack.upgradeButton, (ButtonID)i);
            }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Right) & !PrevState.IsKeyDown(Keys.Right))
            {
                FocusID += 1;
                UpgradeFocus = false;

            }
            if (state.IsKeyDown(Keys.Left) & !PrevState.IsKeyDown(Keys.Left))
            {
                FocusID -= 1;
                UpgradeFocus = false;
            }

            if (state.IsKeyDown(Keys.Down) & !PrevState.IsKeyDown(Keys.Down))
            {
                UpgradeFocus = !UpgradeFocus;
            }
            if (state.IsKeyDown(Keys.Up) & !PrevState.IsKeyDown(Keys.Up))
            {
                UpgradeFocus = !UpgradeFocus;
            }

            if (FocusID < 0)
            {
                FocusID = NumberOfButtons - 1;
            }
            else if (FocusID >= NumberOfButtons)
            {
                FocusID = 0;
            }

            if (state.IsKeyDown(Keys.Enter) & !PrevState.IsKeyDown(Keys.Enter))
            {
                if (!UpgradeFocus)
                {
                    switch ((ButtonID)FocusID)
                    {
                        case ButtonID.cannonForceButton:
                            {
                                Player1.AddForces(new CannonForce(TexturePack, gameTime));
                                break;
                            }
                        case ButtonID.explosiveForceButton:
                            {
                                Player1.AddForces(new ExplosiveForce(TexturePack, gameTime));
                                break;
                            }
                        case ButtonID.rifleForceButton:
                            {
                                Player1.AddForces(new RifleForce(TexturePack, gameTime));
                                break;
                            }
                        case ButtonID.rocketForceButton:
                            {
                                Player1.AddForces(new RocketForce(TexturePack, gameTime));
                                break;
                            }
                        case ButtonID.droneCarrierForceButton:
                            {
                                Player1.AddForces(new DroneCarrierForce(TexturePack, gameTime));
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    Player1.Upgrade((ForcesType)FocusID);
                }
            }
            //TEMP ADDING ENEMY
            if (state.IsKeyDown(Keys.Space) & !PrevState.IsKeyDown(Keys.Space))
            {
                Player2.AddForces(new CannonForce(TexturePack, gameTime));
            }

            PrevState = state;
        }

        private void DrawBasicInterface(SpriteBatch spriteBatch)
        {
            foreach (Button b in Buttons)
            {
                if ((int)b.ButtonId != FocusID)
                {
                    b.DrawBasic(spriteBatch);
                }
                else
                {
                    Buttons[FocusID].DrawFocused(spriteBatch, UpgradeFocus);
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawBasicInterface(spriteBatch);
        }
    }
}
