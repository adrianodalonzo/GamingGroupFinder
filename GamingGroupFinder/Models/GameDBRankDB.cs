using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GamingGroupFinderGUI.Models;

public class GamEDBRankDB {
    [Keyless]
    public class GameDBRankDB {
        [ForeignKey("GameDBId")]
        public int GameDBId { get; set; }
        public GameDB Game { get; set; } = null!;
        [ForeignKey("RankDBId")]
        public int RankDBId { get; set; }
        public RankDB Rank { get; set; } = null!;
    }
}
