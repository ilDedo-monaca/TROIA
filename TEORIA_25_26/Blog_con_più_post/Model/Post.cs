using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_con_più_post.Model;

public class Post
{
public int PostId { get; set; }
public string Title { get; set; }
public string Content { get; set; }
public int BlogID { get; set; }
public Blog Blog { get; set; }
}
