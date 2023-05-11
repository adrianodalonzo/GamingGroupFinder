using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;
using static GamingGroupFinderGUI.Models.GamEDBRankDB;

namespace GamingGroupFinderDatabase;

public class ApplicationContext : DbContext {
    public virtual DbSet<UserDB> UsersDB {get;set;}
    public virtual DbSet<MessageDB> MessagesDB {get;set;}
    public virtual DbSet<ProfileDB> ProfilesDB {get;set;}
    public virtual DbSet<GameDB> GamesDB {get;set;}
    public virtual DbSet<RankDB> RanksDB {get;set;}
    public virtual DbSet<PlatformDB> PlatformsDB {get;set;}
    public virtual DbSet<EventDB> EventsDB {get;set;}
    public virtual DbSet<InterestDB> InterestsDB {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string? oracleUser = Environment.GetEnvironmentVariable("ORACLE_APP_USER");
        string? oraclePassword = Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
        optionsBuilder.UseOracle($"User Id={oracleUser};Password={oraclePassword};Data Source=198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca");
    }
}