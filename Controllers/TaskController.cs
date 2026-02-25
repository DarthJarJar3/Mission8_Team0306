using Microsoft.AspNetCore.Mvc;

public class TaskController : Controller
{
    private readonly ITaskRepository _repo;

    public TaskController(ITaskRepository repo)
    {
        _repo = repo;
    }

    // Quadrants view
    public IActionResult Index()
    {
        var tasks = _repo.Tasks
            .Where(t => !t.Completed)
            .OrderBy(t => t.DueDate);
        return View("Quadrants", tasks);
    }

    // GET: Add
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _repo.Categories.ToList();
        return View("AddEdit", new TaskItem());
    }

    // POST: Add
    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddEdit", task);
        }

        _repo.AddTask(task);
        _repo.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: Edit
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        ViewBag.Categories = _repo.Categories.ToList();
        return View("AddEdit", task);
    }

    // POST: Edit
    [HttpPost]
    public IActionResult Edit(TaskItem task)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddEdit", task);
        }

        _repo.UpdateTask(task);
        _repo.SaveChanges();
        return RedirectToAction("Index");
    }

    // POST: Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        _repo.DeleteTask(task);
        _repo.SaveChanges();
        return RedirectToAction("Index");
    }

    // POST: Mark complete
    [HttpPost]
    public IActionResult Complete(int id)
    {
        var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
        if (task == null) return NotFound();

        task.Completed = true;
        _repo.UpdateTask(task);
        _repo.SaveChanges();
        return RedirectToAction("Index");
    }
}
