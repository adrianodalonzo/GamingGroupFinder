using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroupFinderDatabase;

public class UserDB {
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public ProfileDB? Profile { get; set; }
    [InverseProperty("UsersAttending")]
    public List<EventDB> EventsAttending { get; set; } = new();
    [InverseProperty("Owner")]
    public List<EventDB> EventsOwned { get; set; } = new();

    public UserDB(string username, string password, string salt, ProfileDB profile) {
        this.Username = username;
        this.Password = password;
        this.Salt = salt;
        this.Profile = profile;
    }

    private UserDB() {

    }
}

// public class Contact {
//     public int ContactId { get; set; }
//     public int UserId { get; set; }
//     public User User { get; set; } = null!;
// }

public class ProfileDB {
    public int ProfileId { get; set; }
    public int UserId { get; set; }
    public UserDB User { get; set; } = null!;
    public string Name { get; set; }
    public string Pronouns { get; set; }
    public int Age { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }
    public List<InterestDB> Interests { get; } = new();
    public List<PlatformDB> Platforms { get; } = new();
    public List<GameDB> Games { get; } = new();

    public ProfileDB(UserDB user, string name, string pronouns, int age, string bio, string profilePicture) {
        this.User = user;
        this.Name = name;
        this.Pronouns = pronouns;
        this.Age = age;
        this.Bio = bio;
        this.ProfilePicture = profilePicture;
    }

    private ProfileDB() {

    }
}

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

public class PlatformDB {
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

public class RankDB {
    public int RankId { get; set; }
    public int RankValue { get; set; }
    public string RankName { get; set; }
    public List<GameDB> Games { get; } = new();
    
    public RankDB(int rankValue, string rankName) {
        this.RankValue = rankValue;
        this.RankName = rankName;
    }

    private RankDB() {

    }
}

public class InterestDB {
    public int InterestId { get; set; }
    public string InterestName { get; set; }
    public List<ProfileDB> Profiles { get; } = new();

    public InterestDB(string interestName) {
        this.InterestName = interestName;
    }

    private InterestDB() {

    }
}

public class MessageDB {
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public UserDB Sender { get; set; } = null!;
    public int ReceiverId { get; set; }
    public UserDB Receiver { get; set; } = null!;
    public DateTime Time { get; set; }
    public string MessageText { get; set; }
    public bool IsSeen { get; set; }

    public MessageDB(UserDB sender, UserDB receiver, DateTime time, string messageText, bool isSeen) {
        this.Sender = sender;
        this.Receiver = receiver;
        this.Time = time;
        this.MessageText = messageText;
        this.IsSeen = isSeen;
    }

    private MessageDB() {

    }
}

public class EventDB {
    public int EventId { get; set; }
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