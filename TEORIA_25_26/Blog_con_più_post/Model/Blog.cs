using System;

namespace Blog_con_più_post.Model;

public class Blog
{
    public int BlogID { get; set; }
    public string Url { get; set; } = null!;
    public List<Post> ListaPost { get; set; }=[];
}
