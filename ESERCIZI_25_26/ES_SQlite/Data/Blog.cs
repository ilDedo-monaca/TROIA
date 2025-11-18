using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("Blogs")] // la tabella invece che Blog si chiamerà Blogs
public class Blog
{
    public int BlogId { get; set; }
    [Required] //obbliga a caricarli nella tabella anche se sono nulli 
    public string Url { get; set; }
}
