namespace WebApplication1.Contracts;

/// <summary>
/// Модель данных для добавления комментария
/// </summary>
public class CommentAddDto
{
    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get; set; } = string.Empty;
    
    /// <summary>
    /// Цвет
    /// </summary>
    public string? Color { get; set; } = string.Empty;
    
    /// <summary>
    /// Идентификатор точки
    /// </summary>
    public int PointId { get; set; }
}