using System;
using Microsoft.EntityFrameworkCore;

namespace ES_SQlite.Data;

public class BlogContext:DbContext
{
    public DbSet<Blog> Blog { get; set; }
    public string DbPath;
    public BlogContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "../../../Blog.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }
 
}
