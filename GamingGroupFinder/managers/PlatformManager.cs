using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinder {
    public class PlatformManager {

        private static PlatformManager? _instance;
        private static ApplicationContext db = null!;

        private PlatformManager() {

        }

        public static PlatformManager GetInstance() {
            if(_instance == null) {
                _instance = new PlatformManager();
            }
            return _instance;
        }

        public void SetApplicationContext(ApplicationContext context) {
            db = context;
        }

        public static List<PlatformDB> GetListOfPlatforms() {
            return db.PlatformsDB.ToList();
        }

        public static PlatformDB GetPlatform(string platformName) {
            return (from platform in db.PlatformsDB where platform.PlatformName.Equals(platformName) select platform).SingleOrDefault();
        }
    }
}