using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRatingAsm.Models;

namespace StudentRatingAsm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController
    {
        private readonly StudentRatingContext _context;
        public RatingController(StudentRatingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Rating>> Get()
        {
            return await _context.Ratings.Include(r => r.Course).Include(r => r.Student).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<Rating> Get(int id)
        {
            return await _context.Ratings.Include(r => r.Course).Include(r => r.Student).FirstOrDefaultAsync(a => a.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var stud = new Rating { Id = id };
            _context.Remove(stud);
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task Post(Rating rating)
        {
            Student student = await _context.Students.FindAsync(rating.StudentId);
            rating.Student = student;
            Course course = await _context.Courses.FindAsync(rating.CourseId);
            rating.Course = course;
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task Put(Rating rating)
        {
            Student student = await _context.Students.FindAsync(rating.StudentId);
            rating.Student = student;
            Course course = await _context.Courses.FindAsync(rating.CourseId);
            rating.Course = course;
            _context.Update(rating);
            await _context.SaveChangesAsync();
        }
    }
}
