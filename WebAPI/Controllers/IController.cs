using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IController<T>
    {
        IActionResult Add(T entity);
        IActionResult Delete(T entity);
        IActionResult Update(T entity);
        IActionResult GetAll();
        IActionResult GetById(int id);
    }
}
