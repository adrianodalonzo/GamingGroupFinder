//might need to keep track of logged in user somewhere here (to know whos signed in and who sent/recieved messages)

using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinder;

public class MessageManager {
    private static MessageManager? _instance;
    private static ApplicationContext db = null!;

    private MessageManager() {

    }
    
    public static MessageManager GetInstance(){
        if(_instance == null) {
            _instance = new MessageManager();
        }
        return _instance;
    }

    public void SetApplicationContext(ApplicationContext context) {
        db = context;
    }

    // private Message _message;

    // this is probably just going to create a new message and add it to the database
    public void CreateMessage(Message m) {
        UserDB sender = (from user in db.UsersDB where user.Username.Equals(m.Sender.Username) select user).SingleOrDefault();
        UserDB reciever = (from user in db.UsersDB where user.Username.Equals(m.Recipient.Username) select user).SingleOrDefault();

        MessageDB message = new MessageDB(sender, reciever, m.TimeSent, m.MessageText, m.IsSeen);
        db.Add(message);
        // this._message = m;
        db.SaveChanges();
    }

    // input is the user signed in/current user
    public List<Message> GetMessagesSent(User user) {
        var messagesSent = from message in db.MessagesDB where message.Sender.Username.Equals(user.Username) select message;
        if (messagesSent == null) {
            throw new Exception("User hasn't sent any messages");
        }
        List<Message> messages = (messagesSent.Select(message => new Message(user, UserDBToUser(message.Receiver), message.Time, message.MessageText, message.IsSeen))).ToList();
        return messages;
    }

    private static User UserDBToUser(UserDB user) {
        return new User(user.Username, user.Password, user.Salt, new List<User>());
    }

    // input is the user who sent messages to signed in/current user
    public List<Message> GetMessagesRecieved(User user) {
        var messagesRecieved = from message in db.MessagesDB where message.Receiver.Username.Equals(user.Username) select message;
        if (messagesRecieved == null) {
            throw new Exception("User hasn't recieved any messages");
        }
        List<Message> messages = (messagesRecieved.Select(message => new Message(UserDBToUser(message.Sender), user, message.Time, message.MessageText, message.IsSeen))).ToList();
        return messages;
    }

    public void MarkMessageSeen(Message message) {
        if (message is null) {
            throw new ArgumentNullException("message cannot be null");
        }
        var testMessage = db.MessagesDB.SingleOrDefault(
            m => m.Sender.Username.Equals(message.Sender.Username) &&
            m.Receiver.Username.Equals(message.Recipient.Username) &&
            m.Time.Date.Equals(message.TimeSent.Date)
        );

        if (testMessage == null) {
            throw new Exception("Error occurred trying to find the message");
        }
        
        testMessage.IsSeen = true;
        db.SaveChanges();
    }

}