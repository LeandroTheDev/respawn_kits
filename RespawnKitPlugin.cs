extern alias UnityEngineCoreModule;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using UnityCoreModule = UnityEngineCoreModule.UnityEngine;

namespace RespawnKit
{
    public class RespawnKitPlugin : RocketPlugin<RespawnKitConfiguration>
    {
        public override void LoadPlugin()
        {
            base.LoadPlugin();
            Logger.Log("RespawnKit by LeandroTheDev");
            Rocket.Unturned.U.Events.OnPlayerConnected += OnPlayerConnected;
        }

        private void OnPlayerConnected(UnturnedPlayer player)
        {
            // Check if is first time logging
            if (!System.IO.Directory.Exists(Path.Combine(Configuration.Instance.PlayerPath, $"{player.Id}_0")))
            {
                // Give him a kit
                PlayerRevived(player, UnityCoreModule.Vector3.up, 0);
            }
            // Add the event for player revived
            player.Events.OnRevive += PlayerRevived;
        }

        private void PlayerRevived(UnturnedPlayer player, UnityCoreModule.Vector3 position, byte angle)
        {
            foreach (KitItem item in Configuration.Instance.Items)
            {
                player.GiveItem(item.Id, item.Amount);
            }
        }
    }
}
