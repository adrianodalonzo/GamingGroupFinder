using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class PlatformDB{
    public int PlatformId { get; set; }
    public string PlatformName { get; set; }
    public List<GameDB> Games { get; } = new();
    public List<ProfileDB> Profiles { get; } = new();

    public PlatformDB(string platformName) {
        this.PlatformName = platformName;
    }

    private PlatformDB() {
        
    }
}