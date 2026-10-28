using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCore.Models;

namespace SchoolAppCore.Pages.CoursePages;

public class DetailsModel : PageModel
{
    private readonly SchoolContext _context;
    public DetailsModel(SchoolContext context)
    {
        _context = context;
    }

    public Course Course { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? courseid)
    {
        if (courseid is null)
        {
            return NotFound();
        }

        var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseId == courseid);
        if (course is null)
        {
            return NotFound();
        }
        else
        {
            Course = course;
        }

        return Page();
    }
}
