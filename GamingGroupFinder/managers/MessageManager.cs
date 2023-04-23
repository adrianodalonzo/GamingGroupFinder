//might need to keep track of logged in user somewhere here (to know whos signed in and who sent/recieved messages)

namespace GamingGroupFinderDatabase;

public class MessageManager {

    private Message _message;

    public MessageManager(Message _message) {
        this._message = _message;
    }

    // this is probably just going to create a new message and add it to the database
    public Message CreateMessage(Message m) {
        return null!;
    }

    // input is the user signed in/current user
    public List<Message> GetMessagesSent(User user) {
        return null!;
    }

    // input is the user who sent messages to signed in/current user
    public List<Message> GetMessagesRecieved(User user) {
        return null!;
    }

    public void SendMessage(Message m) {
        
    }

    public void MarkMessageSeen(Message m) {
        
    }

}