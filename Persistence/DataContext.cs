using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext: DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public DbSet<Post> Posts { get; set; }
    
    public string DbPath { get; }

    public DataContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "BlogBox.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}