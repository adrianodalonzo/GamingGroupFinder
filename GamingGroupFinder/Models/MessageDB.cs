using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

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