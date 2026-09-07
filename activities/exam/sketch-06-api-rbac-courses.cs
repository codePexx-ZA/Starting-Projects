using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class CreateCourseRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private static List<Course> _courses = new List<Course>();

    [Authorize(Roles = "Instructor,Admin")]
    [HttpPost]
    public IActionResult Create([FromBody] CreateCourseRequest request)
    {
        var course = new Course { Title = request.Title, Description = request.Description };
        course.Id = _courses.Count + 1;
        _courses.Add(course);
        return Ok(course);
    }

    [Authorize(Roles = "Student,Instructor,Admin")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);
        if (course == null)
        {
            return NotFound();
        }
        _courses.Remove(course);
        return Ok("deleted");
    }
}
