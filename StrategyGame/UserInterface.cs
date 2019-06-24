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
    /// <summary>
    /// Class representing double button for adding and upgrading forces.
    /// </summary>
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

    /// <summary>
    /// Class responsible for handling player input and drawing user interface - buttons, force descriptions, cash balance, upgrade information.
    /// </summary>
    public class UserInterface
    {
        int FocusID { get; set; }
        bool UpgradeFocus { get; set; }
        int NumberOfButtons { get; set; }
        Button[] Buttons { get; set; }
        Player Player1 { get; set; }
        Player Player2 { get; set; }
        FontPack FontPack { get; set; }
        KeyboardState PrevState { get; set; }

        Color tmpColor = Color.Green; // testing engine - changing color

        public UserInterface(Player player1, Player player2,FontPack fontPack)
        {
            FocusID = 0;
            NumberOfButtons = 5;
            FontPack = fontPack;
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

        private void DrawStrings(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(FontPack.BasicFont, Player1.Cash.ToString() + '$', new Vector2(600, 40), Color.Black);
            if (UpgradeFocus)
            {
                spriteBatch.DrawString(FontPack.BasicFont,"Level: " + Player1.Upgrades[FocusID].ToString(), new Vector2(730, 40), Color.GreenYellow);
                spriteBatch.DrawString(FontPack.BasicFont,UpgradePack.UpgradeInfo[FocusID, Player1.Upgrades[FocusID]], new Vector2(600, 130), Color.Pink);
                spriteBatch.DrawString(FontPack.BasicFont, "Upgrade cost: " + UpgradePack.UpgradeCosts[FocusID, Player1.Upgrades[FocusID]].ToString() + "$", new Vector2(600, 170), Color.Pink);
            }
            else
            {
                spriteBatch.DrawString(FontPack.BasicFont, "Level: " + Player1.Upgrades[FocusID].ToString(), new Vector2(730, 40), Color.GreenYellow);
                spriteBatch.DrawString(FontPack.BasicFont, ((ForcesType)FocusID).ToString(), new Vector2(600, 130), Color.Pink);
                spriteBatch.DrawString(FontPack.BasicFont, "Cost: " + PurchasePack.ForceCosts[FocusID], new Vector2(600, 170), tmpColor);
            }
            spriteBatch.End();
        }

        private void ProcessKeyboardInput(GameTime gameTime)
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
                                Player1.AddForces(new CannonForce(gameTime));
                                break;
                            }
                        case ButtonID.explosiveForceButton:
                            {
                                Player1.AddForces(new ExplosiveForce(gameTime));
                                break;
                            }
                        case ButtonID.rifleForceButton:
                            {
                                Player1.AddForces(new RifleForce(gameTime));
                                break;
                            }
                        case ButtonID.rocketForceButton:
                            {
                                Player1.AddForces(new RocketForce(gameTime));
                                break;
                            }
                        case ButtonID.droneCarrierForceButton:
                            {
                                Player1.AddForces(new DroneCarrierForce(gameTime));
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
            if (state.IsKeyDown(Keys.NumPad1) & !PrevState.IsKeyDown(Keys.NumPad1))
            {
                Player2.AddForces(new CannonForce(gameTime));
            }
            if (state.IsKeyDown(Keys.NumPad2) & !PrevState.IsKeyDown(Keys.NumPad2))
            {
                Player2.AddForces(new ExplosiveForce(gameTime));
            }
            if (state.IsKeyDown(Keys.NumPad3) & !PrevState.IsKeyDown(Keys.NumPad3))
            {
                Player2.AddForces(new DroneCarrierForce(gameTime));
            }
            if (state.IsKeyDown(Keys.NumPad4) & !PrevState.IsKeyDown(Keys.NumPad4))
            {
                Player2.AddForces(new RocketForce(gameTime));
            }
            if (state.IsKeyDown(Keys.NumPad5) & !PrevState.IsKeyDown(Keys.NumPad5))
            {
                Player2.AddForces(new RifleForce(gameTime));
            }
            //testing engine
            if (state.IsKeyDown(Keys.Space) & !PrevState.IsKeyDown(Keys.Space))
            {
                //GameEventEngine.Add(new GameEventDelayed(() => { tmpColor = Color.Red; },1.0f));
                //GameEventEngine.Add(new GameEventDelayed(() => { tmpColor = Color.Green; }, 2.0f));
                //GameEventEngine.Add(new GameEventDelayed(() => { tmpColor = Color.Black; }, 3.0f));
                GameEventEngine.Add(new GameEventCyclic(() => { tmpColor = Color.Red; }, 2,5));
            }

            PrevState = state;
        }

        public void Update(GameTime gameTime)
        {
            ProcessKeyboardInput(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawBasicInterface(spriteBatch);
            DrawStrings(spriteBatch);
        }
    }
}
