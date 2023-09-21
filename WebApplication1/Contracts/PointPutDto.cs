namespace WebApplication1.Contracts;

/// <summary>
/// Модель данных для добавления/обновления точки
/// </summary>
public class PointPutDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int? Id { get; set; }
    
    /// <summary>
    /// Позиция X
    /// </summary>
    public int PositionX { get; set; }
    
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
}