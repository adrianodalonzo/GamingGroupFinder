using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroupFinderDatabase;

public class User {
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public Profile? Profile { get; set; }
    [InverseProperty("UsersAttending")]
    public List<Event> EventsAttending { get; set; } = new();
    [InverseProperty("Owner")]
    public List<Event> EventsOwned { get; set; } = new();

    public User(string username, string password, string salt, Profile profile) {
        this.Username = username;
        this.Password = password;
        this.Salt = salt;
        this.Profile = profile;
    }

    private User() {

    }
}

// public class Contact {
//     public int ContactId { get; set; }
//     public int UserId { get; set; }
//     public User User { get; set; } = null!;
// }

public class Profile {
    public int ProfileId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string Name { get; set; }
    public string Pronouns { get; set; }
    public int Age { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }
    public List<Interest> Interests { get; } = new();
    public List<Platform> Platforms { get; } = new();
    public List<Game> Games { get; } = new();

    public Profile(User user, string name, string pronouns, int age, string bio, string profilePicture) {
        this.User = user;
        this.Name = name;
        this.Pronouns = pronouns;
        this.Age = age;
        this.Bio = bio;
        this.ProfilePicture = profilePicture;
    }

    private Profile() {

    }
}

public class Game {
    public int GameId { get; set; }
    public string GameName { get; set; }
    public List<Platform> Platforms { get; } = new();
    public List<Rank> Ranks { get; } = new();
    public List<Profile> Profiles { get; } = new();

    public Game(string gameName) {
        this.GameName = gameName;
    }

    private Game() {

    }
}

public class Platform {
    public int PlatformId { get; set; }
    public string PlatformName { get; set; }
    public List<Game> Games { get; } = new();
    public List<Profile> Profiles { get; } = new();

    public Platform(string platformName) {
        this.PlatformName = platformName;
    }

    private Platform() {
        
    }
}

public class Rank {
    public int RankId { get; set; }
    public int RankValue { get; set; }
    public string RankName { get; set; }
    public List<Game> Games { get; } = new();
    
    public Rank(int rankValue, string rankName) {
        this.RankValue = rankValue;
        this.RankName = rankName;
    }

    private Rank() {

    }
}

public class Interest {
    public int InterestId { get; set; }
    public string InterestName { get; set; }
    public List<Profile> Profiles { get; } = new();

    public Interest(string interestName) {
        this.InterestName = interestName;
    }

    private Interest() {

    }
}

public class Message {
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;
    public int ReceiverId { get; set; }
    public User Receiver { get; set; } = null!;
    public DateTime Time { get; set; }
    public string MessageText { get; set; }
    public bool IsSeen { get; set; }

    public Message(User sender, User receiver, DateTime time, string messageText, bool isSeen) {
        this.Sender = sender;
        this.Receiver = receiver;
        this.Time = time;
        this.MessageText = messageText;
        this.IsSeen = isSeen;
    }

    private Message() {

    }
}

public class Event {
    public int EventId { get; set; }
    public int OwnerId { get; set; }
    public User? Owner { get; set; }
    public string Title { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
    public int GameId { get; set; }
    public Game? Game { get; set; }
    public int PlatformId { get; set; }
    public Platform? Platform { get; set; }
    public int MinRankId { get; set; }
    public Rank? MinRank { get; set; }
    public int MaxRankId { get; set; }
    public Rank? MaxRank { get; set; }
    public string Description { get; set; }
    public List<User> UsersAttending { get; } = new();

    public Event(User owner, string title, DateTime time, string location, Game game, Platform platform, Rank minRank, Rank maxRank, string description) {
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

    private Event() {
        
    }
}