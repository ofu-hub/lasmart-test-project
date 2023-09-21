using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Repository;

/// <summary>
/// Репозиторий для хранения и обработки mock-данных
/// </summary>
public class Repository : IRepository
{
    /// <summary>
    /// Конструктор репозитория с mock данными
    /// </summary>
    public Repository()
    {
        using (var context = new DatabaseContext())
        {
            context.Points.AddRange(
                new Point()
                {
                    PositionX = 100,
                    PositionY = 15,
                    Radius = 10,
                    Color = "Black"
                },
                new Point()
                {
                    PositionX = 300,
                    PositionY = 50,
                    Radius = 40,
                    Color = "Red"
                }
            );
            context.Comments.AddRange(
                new Comment
                {
                    Text = "Comment 1",
                    Color = null,
                    PointId = 1
                },
                new Comment
                {
                    Text = "Comment 2",
                    Color = "Yellow",
                    PointId = 1
                },
                new Comment
                {
                    Text = "Comment 3",
                    Color = null,
                    PointId = 2
                },
                new Comment
                {
                    Text = "Comment 4",
                    Color = "Grey",
                    PointId = 2
                },
                new Comment
                {
                    Text = "Comment 5",
                    Color = null,
                    PointId = 2
                },
                new Comment
                {
                    Text = "Comment 6 looooooooooooooooong comment",
                    Color = "Yellow",
                    PointId = 2
                },
                new Comment
                {
                    Text = "Comment 7",
                    Color = "Grey",
                    PointId = 2
                },
                new Comment
                {
                    Text = "Comment 8",
                    Color = null,
                    PointId = 2
                }
            );
            context.SaveChanges();
        }
    }

    /// <summary>
    /// Удалить точку по идентификатору из mock-данных
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns></returns>
    public async Task<bool> DeletePointByID(int id)
    {
        using (var _context = new DatabaseContext())
        {
            var point = await _context.Points.FirstOrDefaultAsync(i => i.Id == id);
            if (point != null)
            {
                _context.Points.Remove(point);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Получить все точки из mock-данных
    /// </summary>
    /// <returns></returns>
    public async Task<List<Point>> GetAllPoints()
    {
        using (var _context = new DatabaseContext())
        {
            var points = await _context.Points.ToListAsync();
            foreach (var point in points)
            {
                point.Comments = await GetComments(point.Id);
            }
            return points;
        }
    }

    /// <summary>
    /// Добавить точку в mock-данные
    /// </summary>
    /// <param name="point">Модель точки</param>
    /// <returns></returns>
    public async Task<bool> AddPoint(Point point)
    {
        using (var _context = new DatabaseContext())
        {
            try
            {
                await _context.Points.AddAsync(point);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }

    /// <summary>
    /// Получить точку по идентификатору из mock-данных
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns></returns>
    public async Task<Point?> GetPointById(int? id)
    {
        using (var _context = new DatabaseContext())
        {
            var point = await _context.Points.FirstOrDefaultAsync(x => x.Id == id);
            if (point is null)
                return null;
            return point;
        }
    }

    /// <summary>
    /// Обновить данные точки в mock-данных
    /// </summary>
    /// <param name="pointUpdatе">Модель точки</param>
    public async Task UpdatePoint(Point pointUpdatе)
    {
        using (var _context = new DatabaseContext())
        {
            _context.Points.Update(pointUpdatе);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Добавить комментарий к точке в mock-данных
    /// </summary>
    /// <param name="comment">Модель комментария</param>
    /// <returns></returns>
    public async Task<bool> AddComment(Comment comment)
    {
        using (var _context = new DatabaseContext())
        {
            try
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
    
    /// <summary>
    /// Получить все комментарии по идентификатору точки из mock-данных
    /// </summary>
    /// <param name="pointId">Идентификатор</param>
    /// <returns></returns>
    private async Task<List<Comment>> GetComments(int pointId)
    {
        using (var _context = new DatabaseContext())
        {
            return await _context.Comments.Where(i => i.PointId == pointId).ToListAsync();
        }
    }
}