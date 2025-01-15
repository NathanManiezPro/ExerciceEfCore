using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciceEfCore.Data;
using ExerciceEfCore.Models;

namespace ExerciceEfCore.Controllers
{
    public class TodoTasksController : Controller
    {
        private readonly ExerciceEfCoreContext _context;

        public TodoTasksController(ExerciceEfCoreContext context)
        {
            _context = context;
        }

        // GET: TodoTasks
        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Username = username;

            var tasks = await _context.TodoTask.ToListAsync();
            return View(tasks);
        }

        // GET: TodoTasks/Form/{id?}
        public async Task<IActionResult> Form(int? id)
        {
            if (id == null || id == 0) // Ajout d'une nouvelle tâche
            {
                return View(new TodoTask());
            }

            var task = await _context.TodoTask.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: TodoTasks/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TodoTask todoTask)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", todoTask);
            }

            if (todoTask.Id == 0)
            {
             
                _context.Add(todoTask);
            }
            else
            {
               
                _context.Update(todoTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TodoTasks/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.TodoTask.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.TodoTask.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
