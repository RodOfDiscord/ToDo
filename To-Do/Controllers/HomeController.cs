using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using To_Do.Models;

namespace To_Do.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoContext _context;
        public HomeController(ILogger<HomeController> logger, ToDoContext toDoContext)
        {
            _logger = logger;
            _context = toDoContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Models.Task> tasks = _context.Tasks.OrderByDescending(o=>o.Created).ToArray();
            return View(tasks);
        }

        public RedirectResult Add(string name)
        {
            Models.Task task = new Models.Task()
            {
                Content = name,
                Created = DateTime.Now
            };         
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return Redirect("/Home");           
        }
        public RedirectResult DeleteTask(int id)
        {
            Models.Task task = _context.Tasks.Where(i => i.Id == id).Single();
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return Redirect("/Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}