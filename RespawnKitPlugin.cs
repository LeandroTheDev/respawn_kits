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
