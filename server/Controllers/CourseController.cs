using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRatingAsm.Models;

namespace StudentRatingAsm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController
    {
        private readonly StudentRatingContext _context;
        public CourseController(StudentRatingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Course>> Get()
        {
            return await _context.Courses.Include(c => c.Teacher).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<Course> Get(int id)
        {
            return await _context.Courses.Include(c => c.Teacher).FirstOrDefaultAsync(a => a.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var stud = new Course { Id = id };
            _context.Remove(stud);
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task Post(Course course)
        {
            Teacher teacher = await _context.Teachers.FindAsync(course.TeacherId);
            course.Teacher = teacher;
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task Put(Course course)
        {
            Teacher teacher = await _context.Teachers.FindAsync(course.TeacherId);
            course.Teacher = teacher;
            _context.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
