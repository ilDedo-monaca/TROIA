using System;
using Blog_con_più_post.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog_con_più_post.Data;

public class BlogPostContext:DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    string path;
    public BlogPostContext()
    {
        var folder = AppContext.BaseDirectory;
        path = Path.Combine(folder, "../../../BlogPost.db");

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={path}");
    }
   
}
