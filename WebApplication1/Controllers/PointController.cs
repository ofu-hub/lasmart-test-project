using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Contracts;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

/// <summary>
/// Контроллер для работы с точками
/// </summary>
public class PointController : Controller
{
    private readonly IRepository _repository;

    /// <summary>
    /// Конструкторк контроллера
    /// </summary>
    /// <param name="repository">Репозиторий</param>
    public PointController(IRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Получить все точки
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<JsonResult> Get()
    {
        var points = await _repository.GetAllPoints();
        return Json(points);
    }

    /// <summary>
    /// Вставить точку
    /// </summary>
    /// <param name="putPoint">Модель данных для добавления/обновления точки</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<JsonResult> Put([FromForm] PointPutDto putPoint)
    {
        if (!ModelState.IsValid) return Json(BadRequest(ModelState));

        if (putPoint.Id is null)
        {
            var newPoint = new Point
            {
                Id = new Random().Next(int.MinValue, int.MaxValue),
                Color = putPoint.Color,
                Radius = putPoint.Radius,
                PositionX = putPoint.PositionX,
                PositionY = putPoint.PositionY
            };

            await _repository.AddPoint(newPoint);

            return Json(CreatedAtAction(nameof(Get), new { id = newPoint.Id }, newPoint));
        }
        
        var point = await _repository.GetPointById(putPoint.Id);
        if (point is null)
            return Json(NotFound(putPoint.Id));

        point.Color = putPoint.Color;
        point.Radius = putPoint.Radius;

        await _repository.UpdatePoint(point);

        return Json(NoContent());
    }
    
    /// <summary>
    /// Удалить точку по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<JsonResult> Delete(int id)
    {
        if (await _repository.DeletePointByID(id))
        {
            return Json(true);
        }
        return Json(false);
    }

    /// <summary>
    /// Обновить позицию точки
    /// </summary>
    /// <param name="pointUpdateDto">Модель данных для обновления позиции точки</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<JsonResult> Update(PointUpdateDto pointUpdateDto)
    {
        var point = await _repository.GetPointById(pointUpdateDto.Id);
        if (point != null)
        {
            point.PositionX = (int)pointUpdateDto.PositionX;
            point.PositionY = (int)pointUpdateDto.PositionY;
            await _repository.UpdatePoint(point);
            return Json(point);
        }
        return Json(false);
    }
}