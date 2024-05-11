using StardewModdingAPI.Events;
using StardewModdingAPI;
using StardewValley.Menus;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlimitedCommunityCenter
{
    internal class ModEntry : Mod
    {

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.OneSecondUpdateTicked += this.OnOneSecondUpdateTicked; //game tick event handler
        }

        private void OnOneSecondUpdateTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {
            this.PauseIfNobodyPresent();
        }

        private void PauseIfNobodyPresent()
        {
            if (Context.IsWorldReady)
            {
                List<ChatMessage> messages = this.Helper.Reflection.GetField<List<ChatMessage>>(Game1.chatBox, "messages").GetValue();

                if (messages.Count > 0)
                {
                    var messagetoconvert = messages[messages.Count - 1].message;
                    string actualmessage = ChatMessage.makeMessagePlaintext(messagetoconvert, true);
                    string lastFragment = actualmessage.Split(' ')[1];

                    if (lastFragment != null && lastFragment == "!BoilerRoom")
                    {
                        if (Game1.player.mailReceived.Contains("ccBoilerRoom"))
                        {
                            this.SendChatMessage("Boiler Room already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenBoilerRoomForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!Bulletin")
                    {
                        if (Game1.player.mailReceived.Contains("ccBulletin"))
                        {
                            this.SendChatMessage("Bulletin already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenBulletinForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!CraftsRoom")
                    {
                        if (Game1.player.mailReceived.Contains("ccCraftsRoom"))
                        {
                            this.SendChatMessage("Crafts Room already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenCraftsRoomForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!FishTank")
                    {
                        if (Game1.player.mailReceived.Contains("ccFishTank"))
                        {
                            this.SendChatMessage("Fish Tank already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenFishTankForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!Pantry")
                    {
                        if (Game1.player.mailReceived.Contains("ccPantry"))
                        {
                            this.SendChatMessage("Pantry already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenPantryForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!Vault")
                    {
                        if (Game1.player.mailReceived.Contains("ccVault"))
                        {
                            this.SendChatMessage("Vault already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenVaultForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!jojaBoilerRoom")
                    {
                        if (Game1.player.mailReceived.Contains("jojaBoilerRoom"))
                        {
                            this.SendChatMessage("Joja Boiler Room already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenjojaBoilerRoomForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!jojaCraftsRoom")
                    {
                        if (Game1.player.mailReceived.Contains("jojaCraftsRoom"))
                        {
                            this.SendChatMessage("Joja Crafts Room already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenjojaCraftsRoomForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!jojaFishTank")
                    {
                        if (Game1.player.mailReceived.Contains("jojaFishTank"))
                        {
                            this.SendChatMessage("Joja Fish Tank already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenjojaFishTankForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!jojaPantry")
                    {
                        if (Game1.player.mailReceived.Contains("jojaPantry"))
                        {
                            this.SendChatMessage("Joja Pantry already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenjojaPantryForSelf();
                        }
                    }

                    if (lastFragment != null && lastFragment == "!jojaVault")
                    {
                        if (Game1.player.mailReceived.Contains("jojaVault"))
                        {
                            this.SendChatMessage("Joja Vault already open for you.");
                        }
                        else
                        {
                            this.CheckAndOpenjojaVaultForSelf();
                        }
                    }



                }
            }
        }


        private void CheckAndOpenBoilerRoomForSelf()
        {
            Farmer player = Game1.player;

            bool boilerRoomOpen = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("ccBoilerRoodom"));

            if (boilerRoomOpen)
            {
                player.mailReceived.Add("ccBoilerRoom");
                this.SendChatMessage("BoilerRoom open!");
            } else {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenBulletinForSelf()
        {
            Farmer player = Game1.player;

            bool Bulletin = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("ccBulletin"));

            if (Bulletin)
            {
                player.mailReceived.Add("ccBulletin");
                this.SendChatMessage("Bulletin complete!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenCraftsRoomForSelf()
        {
            Farmer player = Game1.player;

            bool ccFishTank = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("ccCraftsRoom"));

            if (ccFishTank)
            {
                player.mailReceived.Add("ccCraftsRoom");
                this.SendChatMessage("Crafts Room open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenFishTankForSelf()
        {
            Farmer player = Game1.player;

            bool FishTank = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("ccFishTank"));

            if (FishTank)
            {
                player.mailReceived.Add("ccFishTank");
                this.SendChatMessage("Fish Tank open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenPantryForSelf()
        {
            Farmer player = Game1.player;

            bool Pantry = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("ccPantry"));

            if (Pantry)
            {
                player.mailReceived.Add("ccPantry");
                this.SendChatMessage("Pantry open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenVaultForSelf()
        {
            Farmer player = Game1.player;

            bool Vault = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("ccVault"));

            if (Vault)
            {
                player.mailReceived.Add("ccVault");
                this.SendChatMessage("Vault open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenjojaBoilerRoomForSelf()
        {
            Farmer player = Game1.player;

            bool jojaBoilerRoom = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("jojaBoilerRoom"));

            if (jojaBoilerRoom)
            {
                player.mailReceived.Add("jojaBoilerRoom");
                this.SendChatMessage("Joja Boiler Room open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenjojaCraftsRoomForSelf()
        {
            Farmer player = Game1.player;

            bool boilerRoomOpen = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("jojaCraftsRoom"));

            if (boilerRoomOpen)
            {
                player.mailReceived.Add("jojaCraftsRoom");
                this.SendChatMessage("Joja Fish Tank open!");
            }
        }

        private void CheckAndOpenjojaFishTankForSelf()
        {
            Farmer player = Game1.player;

            bool boilerRoomOpen = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("jojaFishTank"));

            if (boilerRoomOpen)
            {
                player.mailReceived.Add("jojaFishTank");
                this.SendChatMessage("Joja Fish Tank open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenjojaPantryForSelf()
        {
            Farmer player = Game1.player;

            bool boilerRoomOpen = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("jojaPantry"));

            if (boilerRoomOpen)
            {
                player.mailReceived.Add("jojaPantry");
                this.SendChatMessage("Joja Pantry open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }

        private void CheckAndOpenjojaVaultForSelf()
        {
            Farmer player = Game1.player;

            bool boilerRoomOpen = Game1.getAllFarmers().Any(farmer => farmer.mailReceived.Contains("jojaVault"));

            if (boilerRoomOpen)
            {
                player.mailReceived.Add("jojaVault");
                this.SendChatMessage("Joja Vault open!");
            }
            else
            {
                this.SendChatMessage("It's not open to anyone!");
            }
        }


        /// <summary>Send a chat message.</summary>
        /// <param name="message">The message text.</param>
        private void SendChatMessage(string message)
        {
            Game1.chatBox.activate();
            Game1.chatBox.setText(message);
            Game1.chatBox.chatBox.RecieveCommandInput('\r');
        }



    }

}
