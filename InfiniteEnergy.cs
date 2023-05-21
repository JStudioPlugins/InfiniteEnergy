using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteEnergy
{
    public class InfiniteEnergy : RocketPlugin
    {
        protected override void Load()
        {
            UnturnedPlayerEvents.OnPlayerUpdateStamina += HandlePlayerStaminaUpdate;
            U.Events.OnPlayerConnected += HandlePlayerConnected;
            Logger.Log("InfiniteEnergy by JStudio has now been loaded");
        }
        private void HandlePlayerConnected(Rocket.Unturned.Player.UnturnedPlayer player)
        {
            player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.ShowStamina);
        }
        private void HandlePlayerStaminaUpdate(Rocket.Unturned.Player.UnturnedPlayer player, byte stamina)
        {
            if (stamina <= 50)
                player.Player.life.serverModifyStamina(100);
        }
        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerUpdateStamina -= HandlePlayerStaminaUpdate;
            U.Events.OnPlayerConnected -= HandlePlayerConnected;
            foreach (SteamPlayer player in Provider.clients)
                player.player.enablePluginWidgetFlag(EPluginWidgetFlags.ShowStamina);
            Logger.Log("InfiniteEnergy by JStudio has now been unloaded. UI changes restored.");
        }
    }
}
