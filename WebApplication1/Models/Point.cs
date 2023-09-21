namespace WebApplication1.Models;

/// <summary>
/// Модель точки
/// </summary>
public class Point
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Позиция X
    /// </summary>
    public int PositionX  { get; set; }
    
    /// <summary>
    /// Позиция Y
    /// </summary>
    public int PositionY { get; set; }
    
    /// <summary>
    /// Радиус
    /// </summary>
    public int Radius { get; set; }
    
    /// <summary>
    /// Цвет
    /// </summary>
    public string Color { get; set; } = string.Empty;
    
    /// <summary>
    /// Список комментариев
    /// </summary>
    public virtual List<Comment> Comments { get; set; } = new List<Comment>();
}