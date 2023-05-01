using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingGroupFinderDatabase;

public class ApplicationContext : DbContext {
    public DbSet<UserDB> Users {get;set;}
    public DbSet<MessageDB> Messages {get;set;}
    public DbSet<ProfileDB> Profiles {get;set;}
    // public DbSet<Contact> Contacts {get;set;}
    public DbSet<GameDB> Games {get;set;}
    public DbSet<RankDB> Ranks {get;set;}
    public DbSet<PlatformDB> Platforms {get;set;}
    public DbSet<EventDB> Events {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string? oracleUser = Environment.GetEnvironmentVariable("ORACLE_APP_USER");
        string? oraclePassword = Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
        optionsBuilder.UseOracle($"User Id={oracleUser};Password={oraclePassword};Data Source=198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca");
    }
}