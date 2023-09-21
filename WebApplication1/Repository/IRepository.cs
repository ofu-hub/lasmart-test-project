using WebApplication1.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Repository;

/// <summary>
/// Интерфейс (контракт) репозитория
/// </summary>
public interface IRepository
{
    Task<List<Point>> GetAllPoints();
    Task<bool> DeletePointByID(int id);
    Task<bool> AddPoint(Point point);
    Task<Point?> GetPointById(int? id);
    Task UpdatePoint(Point pointUpdate);
    Task<bool> AddComment(Comment comment);
}