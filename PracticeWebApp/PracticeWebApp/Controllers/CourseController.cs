
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeWebApp.Models;

public class CourseController : Controller
{
    private readonly PracticeDBContext _context;

    public CourseController(PracticeDBContext context)
    {
        _context = context;
    }

    // GET: COURSES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.courses.ToListAsync());
    }

    // GET: COURSES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.courses
            .FirstOrDefaultAsync(m => m.CourseId == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // GET: COURSES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: COURSES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CourseId,CourseName")] Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    // GET: COURSES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return View(course);
    }

    // POST: COURSES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("CourseId,CourseName")] Course course)
    {
        if (id != course.CourseId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(course.CourseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    // GET: COURSES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.courses
            .FirstOrDefaultAsync(m => m.CourseId == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // POST: COURSES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var course = await _context.courses.FindAsync(id);
        if (course != null)
        {
            _context.courses.Remove(course);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseExists(int? id)
    {
        return _context.courses.Any(m => m.CourseId == id);
    }
}
