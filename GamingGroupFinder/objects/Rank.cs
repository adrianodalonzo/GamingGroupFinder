namespace GamingGroupFinder {
    public class Rank {
        private int _rankId;
        private int _rankValue;
        private string _rankName;

        public int RankId {
            get {return _rankId;}
            set {
                if (value < 0) {
                    throw new ArgumentException("RankId must be greater than 0");
                }
                this._rankId = value;
            }
        }

        public int RankValue {
            get {return _rankValue;}
            set {
                if (value < 0) {
                    throw new ArgumentException("RankValue must be greater than 0");
                }
                this._rankValue = value;
            }
        }

        public string RankName {
            get {return _rankName;}
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("RankName must not be null or empty");
                }
                this._rankName = value;
            }
        }

        public Rank(int RankId, int RankValue, string RankName) {
            this.RankId = RankId;
            this.RankValue = RankValue;
            this.RankName = RankName;
        }

        public Rank(int RankValue, string RankName) {
            this.RankValue = RankValue;
            this.RankName = RankName;
        }

        private Rank() {
        }
    }
}