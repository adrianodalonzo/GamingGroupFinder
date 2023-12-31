namespace GamingGroupFinder {
    public class Platform{
        private int _platformId;
        public int PlatformId{
            get{ return _platformId; }
            set {
                if (value < 0){
                    throw new ArgumentNullException("Platform ID is negative");
                }
                this._platformId = value;
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
        public Platform(int platformId, string name){
            if (platformId < 0 || name == null){
                throw new ArgumentNullException("one or multiple of the input is null or negative");
            }
            this.PlatformId = platformId;
            this.Name = name;
        }

        public Platform(string name){
            if (name == null){
                throw new ArgumentNullException("Name can't be null!");
            }
            this.Name = name;
        }
        private Platform(){
        }
    }
}