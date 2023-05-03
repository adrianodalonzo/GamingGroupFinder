using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinder {
    public class GameManager {

        private static GameManager? _instance;
        private static ApplicationContext db = null!;

        private GameManager() {

        }

        public static GameManager GetInstance() {
            if(_instance == null) {
                _instance = new GameManager();
            }
            return _instance;
        }

        public void SetApplicationContext(ApplicationContext context) {
            db = context;
        }

        public static List<GameDB> GetListOfGames() {
            return db.GamesDB.ToList();
        }
    }
}