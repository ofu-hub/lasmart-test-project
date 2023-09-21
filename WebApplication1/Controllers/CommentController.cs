using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

/// <summary>
/// Контроллер для работы с комментариями
/// </summary>
public class CommentController : Controller
{
    private readonly IRepository _repository;

    /// <summary>
    /// Конструктор контроллера
    /// </summary>
    /// <param name="repository">Репотизиторий для работы с данными</param>
    public CommentController(IRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Добавление комментария
    /// </summary>
    /// <param name="commentAddDto">Модель данных для добавления комментария</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<JsonResult> Add([FromForm] CommentAddDto commentAddDto)
    {
        if (!ModelState.IsValid) return Json(BadRequest(ModelState));

        var newComment = new Comment()
        {
            Id = new Random().Next(int.MinValue, int.MaxValue),
            Color = commentAddDto.Color,
            Text = commentAddDto.Text,
            PointId = commentAddDto.PointId
        };

        await _repository.AddComment(newComment);

        
        return Json(StatusCodes.Status201Created);
    }
}