using System;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;

namespace CustomChatFormat
{
    public class CustomChatFormat : RocketPlugin
    {
        protected override void Load()
        {
            InitResources();
            
            U.Events.OnPlayerConnected += PlayerJoined;
            U.Events.OnPlayerDisconnected += PlayerLeft;
            UnturnedPlayerEvents.OnPlayerChatted += PlayerChatted;
            UnturnedPlayerEvents.OnPlayerDeath += PlayerDied;
            
            if (!Configuration.Map.SendWelcomeMessageToConsole) return;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("   ____ ____ _____   Welcome to CustomChatFormat!\n");
            Console.Write("  / ___/ ___|  ___|  A plugin by Xpoxy\n");
            Console.Write(" | |  | |   | |_     \n");
            Console.Write(" | |__| |___|  _|    \n");
            Console.Write("  \\____\\____|_|    Version 01.28.24.01\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            // dont add code here
        }

        private void PlayerJoined(UnturnedPlayer uplayer) {}
        private void PlayerLeft(UnturnedPlayer uplayer) {}

        private void PlayerChatted(UnturnedPlayer uplayer, ref UnityEngine.Color color, string message,
            EChatMode chatMode, ref bool cancel)
        {
            cancel = true;
        }
        private void PlayerDied(UnturnedPlayer uplayer, EDeathCause cause, ELimb limb, CSteamID murderer) {}
        
        private void InitResources()
        {
            try { Configuration.LoadConfig(); }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("[CCF] Error while loading resources! Delete the configuration file\n");
                Console.Write("or contact the developer (Xpoxy) for a future fix if this issue continues!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}