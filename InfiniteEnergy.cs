using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
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
            UnturnedPlayerEvents.OnPlayerUpdateStamina += UnturnedPlayerEvents_OnPlayerUpdateStamina;
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateStamina(Rocket.Unturned.Player.UnturnedPlayer player, byte stamina)
        {
            if (stamina <= 50)
            {
                player.Player.life.serverModifyStamina(100);
            }
        }

        protected override void Unload()
        {
            
        }
    }
}
