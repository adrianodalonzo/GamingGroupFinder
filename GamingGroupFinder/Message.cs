namespace GamingGroupFinder {
    public class Message {
        // DateTime myDateTime = DateTime.Now;
        // string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
        
        public User Sender{
            get{ return Sender; }
            set {
                if (value == null){
                    throw new ArgumentNullException("sender is null");
                }
                this.Sender = value;
            }
        }
        public User Recipient{
            get{ return Recipient; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Recipient is null");
                }
                this.Recipient = value;
            }
        }
        public DateTime TimeSent{
            get{ return TimeSent; }
            set {
                if (value == null){
                    throw new ArgumentNullException("TimeSent is null");
                }
                this.TimeSent = value;
            }
        }
        public string MessageText{
            get{ return MessageText; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Message is null");
                }
                this.MessageText = value;
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

        public void ListMessages() {
            
        }

        public void MarkSeen() {
            this.IsSeen = true;
        }
    }
}