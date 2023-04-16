using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingGroupFinderDatabase;

public class User {

    [Key]
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public Profile Profile { get; set; }
}

public class Profile {
    [Key]
    public string Username { get; set; }
}

public class Message {
    public int MessageId { get; set; }
    public string SenderUsername { get; set; }
    public User Sender { get; set; } = null!;
    public string ReceiverUsername { get; set; }
    public User Receiver { get; set; } = null!;
    public DateTime Time { get; set; }
    public string MessageText { get; set; }
    public bool IsSeen { get; set; }
}