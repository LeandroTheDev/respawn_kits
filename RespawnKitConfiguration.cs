using Rocket.API;

namespace RespawnKit
{
    public class RespawnKitConfiguration : IRocketPluginConfiguration
    {
        public List<KitItem> Items = new();
        public string PlayerPath = "C:\\SteamLibrary\\steamapps\\common\\U3DS\\Servers\\myserver\\Players";
        public void LoadDefaults()
        {
            Items = new()
            {
                new()
                {
                    Id = 1,
                    Amount = 1,
                },
                new()
                {
                    Id = 5,
                    Amount = 3,
                }
            };
        }
    }
    public class KitItem
    {
        public ushort Id = 1;
        public byte Amount = 1;
    }
}
