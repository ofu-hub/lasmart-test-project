namespace WebApplication1.Contracts;

/// <summary>
/// Модель данных для обновления координат точки
/// </summary>
public class PointUpdateDto
{
    /// <summary>
    /// Идетификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Позиция X
    /// </summary>
    public int PositionX { get; set; }
    
    /// <summary>
    /// Позиция Y
    /// </summary>
    public int PositionY { get; set; }
}