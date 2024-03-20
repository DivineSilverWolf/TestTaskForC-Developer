using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Config
{
    public class AppSettings
    {
        public bool ShowingAllGameModes { get; set; }
        public string SelectedGameMode { get; set; }
        public GameModesSettings GameModes { get; set; }
        public int PlayCount {get; set;}
    }
    public class GameModesSettings
    {
        public string OnePlayer { get; set; }
        public string TwoPlayers { get; set; }
    }
}