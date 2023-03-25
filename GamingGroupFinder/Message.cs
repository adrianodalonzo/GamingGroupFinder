namespace GamingGroupFinder {
    public class Message {
        private User sender;
        private User recipient;
        private DateTime timeSent;
        private string message;
        private bool isSeen;

        public Message(User sender, User recipient, DateTime timeSent, string message, bool isSeen) {
            this.sender = sender;
            this.recipient = recipient;
            this.timeSent = DateTime.Now;
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