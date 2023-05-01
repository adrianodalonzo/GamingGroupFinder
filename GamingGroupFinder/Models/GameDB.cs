using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class GameDB {
    public int GameId { get; set; }
    public string GameName { get; set; }
    public List<PlatformDB> Platforms { get; } = new();
    public List<RankDB> Ranks { get; } = new();
    public List<ProfileDB> Profiles { get; } = new();

    public GameDB(string gameName) {
        this.GameName = gameName;
    }

    private GameDB() {

    }
}