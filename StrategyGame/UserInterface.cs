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
        DataCollector Data { get; set; }

        Color tmpColor = Color.Green; // testing engine - changing color

        public UserInterface(Player player1, Player player2, FontPack fontPack, DataCollector data)
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
            Data = data;
        }

        private void CreateButtons(Button[] buttons)
        {
            for (int i = 0; i < NumberOfButtons; i++)
            {
                buttons[i] = new Button(i * 110, 0, TexturePack.ButtonFocused, TexturePack.Button, TexturePack.upgradeButtonFocused, TexturePack.upgradeButton, (ButtonID)i);
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

            //draw vechicles on buttons
            Texture2D texture = TexturePack.explosiveForce;
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Vector2( 5, 10 ), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, new Vector2(0, 0), 0.16f, SpriteEffects.None, 1);
            texture = TexturePack.rifleForce;
            spriteBatch.Draw(texture, new Vector2(115, 10), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, new Vector2(0, 0), 0.16f, SpriteEffects.None, 1);
            texture = TexturePack.rocketForce;
            spriteBatch.Draw(texture, new Vector2(225, 10), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, new Vector2(0, 0), 0.16f, SpriteEffects.None, 1);
            texture = TexturePack.droneCarrierForce;
            spriteBatch.Draw(texture, new Vector2(335, 10), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, new Vector2(0, 0), 0.16f, SpriteEffects.None, 1);
            texture = TexturePack.cannonForce;
            spriteBatch.Draw(texture, new Vector2(445, 10), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0, new Vector2(0, 0), 0.16f, SpriteEffects.None, 1);
            spriteBatch.End();
        }

        private void DrawStrings(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(FontPack.BasicFont, Player1.Cash.ToString() + '$', new Vector2(560, 20), Color.Black);
            //spriteBatch.DrawString(FontPack.BasicFont, Player2.Cash.ToString() + '$', new Vector2(900, 20), Color.Black);
            spriteBatch.DrawString(FontPack.BasicFont, "Base HP:", new Vector2(10, 450), Color.Black);
            spriteBatch.DrawString(FontPack.BasicFont, "Base HP:", new Vector2(650, 450), Color.Black);
            if (UpgradeFocus)
            {
                spriteBatch.DrawString(FontPack.BasicFont, "Level: " + Player1.Upgrades[FocusID].ToString(), new Vector2(560, 140), tmpColor);
                spriteBatch.DrawString(FontPack.BasicFont, UpgradePack.UpgradeInfo[FocusID, Player1.Upgrades[FocusID]], new Vector2(560, 60), tmpColor);
                spriteBatch.DrawString(FontPack.BasicFont, "Upgrade cost: " + UpgradePack.UpgradeCosts[FocusID, Player1.Upgrades[FocusID]].ToString() + "$", new Vector2(560, 100), tmpColor);
            }
            else
            {
                spriteBatch.DrawString(FontPack.BasicFont, "Level: " + Player1.Upgrades[FocusID].ToString(), new Vector2(560, 140), tmpColor);
                spriteBatch.DrawString(FontPack.BasicFont, ((ForcesType)FocusID).ToString(), new Vector2(560, 60), tmpColor);
                spriteBatch.DrawString(FontPack.BasicFont, "Cost: " + PurchasePack.ForceCosts[FocusID], new Vector2(560, 100), tmpColor);
            }
            spriteBatch.End();
        }

        private void DrawWin(SpriteBatch spriteBatch,int winner)
        {
            if(winner!=0)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(FontPack.BasicFont, "Win of player " + winner.ToString(), new Vector2(400, 200), Color.Black);
                spriteBatch.End();
            }
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
                        case ButtonID.explosiveForceButton:
                            {
                                Player1.AddForces(new ExplosiveForce(gameTime),Player2, gameTime);
                                break;
                            }
                        case ButtonID.rifleForceButton:
                            {
                                Player1.AddForces(new RifleForce(gameTime), Player2, gameTime);
                                break;
                            }
                        case ButtonID.rocketForceButton:
                            {
                                Player1.AddForces(new RocketForce(gameTime), Player2, gameTime);
                                break;
                            }
                        case ButtonID.droneCarrierForceButton:
                            {
                                Player1.AddForces(new DroneCarrierForce(gameTime), Player2, gameTime);
                                break;
                            }
                        case ButtonID.cannonForceButton:
                            {
                                Player1.AddForces(new CannonForce(gameTime), Player2, gameTime);
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    LearnInputOutput learning = new LearnInputOutput(Player2.ListOfForces, Player1.ListOfForces, Player1.Upgrades,Player1.Cash, (int)((int)((ForcesType)FocusID) + 6));
                    Data.WriteToFile(learning);
                    Player1.DidSomething(gameTime);
                    Player1.Upgrade((ForcesType)FocusID);
                }
            }
            //TEMP ADDING ENEMY
            /*
            if (state.IsKeyDown(Keys.NumPad1) & !PrevState.IsKeyDown(Keys.NumPad1))
            {
                Player2.AddForces(new ExplosiveForce(gameTime), Player1, gameTime);
            }
            if (state.IsKeyDown(Keys.NumPad2) & !PrevState.IsKeyDown(Keys.NumPad2))
            {
                Player2.AddForces(new RifleForce(gameTime), Player1, gameTime);
            }
            if (state.IsKeyDown(Keys.NumPad3) & !PrevState.IsKeyDown(Keys.NumPad3))
            {
                Player2.AddForces(new RocketForce(gameTime), Player1, gameTime);      
            }
            if (state.IsKeyDown(Keys.NumPad4) & !PrevState.IsKeyDown(Keys.NumPad4))
            {
                Player2.AddForces(new DroneCarrierForce(gameTime), Player1, gameTime);
            }
            if (state.IsKeyDown(Keys.NumPad5) & !PrevState.IsKeyDown(Keys.NumPad5))
            {
                
                Player2.AddForces(new CannonForce(gameTime), Player1, gameTime);
            }
            //TEMP UPGRADING ENEMY
            if (state.IsKeyDown(Keys.NumPad0) & !PrevState.IsKeyDown(Keys.NumPad0))
            {
                Player2.Upgrade((ForcesType)0);
            }
            if (state.IsKeyDown(Keys.NumPad6) & !PrevState.IsKeyDown(Keys.NumPad6))
            {
                Player2.Upgrade((ForcesType)1);
            }
            if (state.IsKeyDown(Keys.NumPad7) & !PrevState.IsKeyDown(Keys.NumPad7))
            {
                Player2.Upgrade((ForcesType)2);
            }
            if (state.IsKeyDown(Keys.NumPad8) & !PrevState.IsKeyDown(Keys.NumPad8))
            {
                Player2.Upgrade((ForcesType)3);
            }
            if (state.IsKeyDown(Keys.NumPad9) & !PrevState.IsKeyDown(Keys.NumPad9))
            {
                Player2.Upgrade((ForcesType)4);
            }
            //testing engine
            if (state.IsKeyDown(Keys.Space) & !PrevState.IsKeyDown(Keys.Space))
            {
                //GameEventEngine.Add(new GameEventDelayed(() => { tmpColor = Color.Red; },1.0f));
                //GameEventEngine.Add(new GameEventDelayed(() => { tmpColor = Color.Green; }, 2.0f));
                //GameEventEngine.Add(new GameEventDelayed(() => { tmpColor = Color.Black; }, 3.0f));
                //GameEventEngine.Add(new GameEventCyclic(() => { tmpColor = Color.Red; }, 2, 5));
            }
            */

            PrevState = state;
        }

        public void Update(GameTime gameTime)
        {
            ProcessKeyboardInput(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, int winner,double hp1, double hp2)
        {
            DrawBasicInterface(spriteBatch);
            DrawStrings(spriteBatch);
            DrawWin(spriteBatch, winner);
            HpBarBase.Draw(spriteBatch, new Vector2(140, 455), 20, hp1 / 1000.0);
            HpBarBase.Draw(spriteBatch, new Vector2(780, 455), 20, hp2 / 1000.0);
        }
    }
}
