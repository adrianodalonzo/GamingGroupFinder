using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinder {
    public class InterestManager {

        private static InterestManager? _instance;
        private static ApplicationContext db = null!;

        private InterestManager() {

        }

        public static InterestManager GetInstance() {
            if(_instance == null) {
                _instance = new InterestManager();
            }
            return _instance;
        }

        public void SetApplicationContext(ApplicationContext context) {
            db = context;
        }

        public static List<InterestDB> GetListOfInterests() {
            return db.InterestsDB.ToList();
        }
    }
}