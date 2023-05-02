using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class EventDB {
    public int EventDBId { get; set; }
    public int OwnerId { get; set; }
    public UserDB? Owner { get; set; }
    public string Title { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
    public int GameId { get; set; }
    public GameDB? Game { get; set; }
    public int PlatformId { get; set; }
    public PlatformDB? Platform { get; set; }
    public int MinRankId { get; set; }
    public RankDB? MinRank { get; set; }
    public int MaxRankId { get; set; }
    public RankDB? MaxRank { get; set; }
    public string Description { get; set; }
    public List<UserDB> UsersAttending { get; } = new();

    public EventDB(UserDB owner, string title, DateTime time, string location, GameDB game, PlatformDB platform, RankDB minRank, RankDB maxRank, string description) {
        this.Owner = owner;
        this.Title = title;
        this.Time = time;
        this.Location = location;
        this.Game = game;
        this.Platform = platform;
        this.MinRank = minRank;
        this.MaxRank = maxRank;
        this.Description = description;
    }

    private EventDB() {
        
    }
}