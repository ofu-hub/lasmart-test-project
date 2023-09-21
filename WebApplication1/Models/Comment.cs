namespace WebApplication1.Models;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string? Color { get; set; } = string.Empty;
    public int PointId { get; set; }
    public virtual Point Point { get; set; } = null!;
}