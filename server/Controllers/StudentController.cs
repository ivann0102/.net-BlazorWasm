using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRatingAsm.Models;

namespace StudentRatingAsm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController
    {
        private readonly StudentRatingContext _context;
        public StudentController(StudentRatingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _context.Students.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(a => a.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var stud = new Student { Id = id };
            _context.Remove(stud);
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task Post(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task Put(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
