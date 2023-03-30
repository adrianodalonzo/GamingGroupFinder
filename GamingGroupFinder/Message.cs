namespace GamingGroupFinder {
    public class Message {
        // DateTime myDateTime = DateTime.Now;
        // string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
        
        private User sender;
        private User recipient;
        private DateTime timeSent;
        private string message;
        private bool isSeen;
        public bool IsSeen {get {return isSeen;}}

        public Message(User sender, User recipient, DateTime timeSent, string message, bool isSeen) {
            this.sender = sender;
            this.recipient = recipient;
            this.timeSent = timeSent;
            this.message = message;
            this.isSeen = isSeen;
        }

        public void ListMessages() {
            
        }

        public void MarkSeen() {
            this.isSeen = true;
        }
    }
}