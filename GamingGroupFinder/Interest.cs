namespace GamingGroupFinder {
    public class Interest{
        private int _interestId;
        public int InterestId{
            get{ return _interestId; }
            set {
                if (value < 0){
                    throw new ArgumentNullException("Name is negative");
                }
                this._interestId = value;
            }
        }
        private string _name;
        public string Name{
            get{ return _name; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Name is null");
                }
                this._name = value;
            }
        }
        public Interest(int interestId, string name){
            if (interestId < 0 || name == null){
                throw new ArgumentNullException("one or multiple of the input is null or negative");
            }
            this.InterestId = interestId;
            this.Name = name;
        }
        private Interest(){
        }
    }
}