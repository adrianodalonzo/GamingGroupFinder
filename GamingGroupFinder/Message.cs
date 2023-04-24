using GamingGroupFinderDatabase;

namespace GamingGroupFinder {
    public class Message {
        // DateTime myDateTime = DateTime.Now;
        // string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
        private User _sender;
        public User Sender{
            get{ return _sender; }
            set {
                if (value == null){
                    throw new ArgumentNullException("sender is null");
                }
                this._sender = value;
            }
        }
        private User _recipient;
        public User Recipient{
            get{ return _recipient; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Recipient is null");
                }
                this._recipient = value;
            }
        }
        private DateTime _timeSent;
        public DateTime TimeSent{
            get{ return _timeSent; }
            set {
                if (value == null){
                    throw new ArgumentNullException("TimeSent is null");
                }
                this._timeSent = value;
            }
        }
        private string _messageText;
        public string MessageText{
            get{ return _messageText; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Message is null");
                }
                this._messageText = value;
            }
        }
        public bool IsSeen { get; set; }

        public Message(User sender, User recipient, DateTime timeSent, string message, bool isSeen) {
            if(sender == null || recipient == null || timeSent == null || message == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Sender = sender;
            this.Recipient = recipient;
            this.TimeSent = timeSent;
            this.MessageText = message;
            this.IsSeen = isSeen;
        }
        private Message(){
        }

        public void ListMessages() {
            
        }

        public void MarkSeen() {
            this.IsSeen = true;
        }
    }
}