using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRatingAsm.Models;

namespace StudentRatingAsm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController
    {
        private readonly StudentRatingContext _context;
        public TeacherController(StudentRatingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Teacher>> Get()
        {
            return await _context.Teachers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<Teacher> Get(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(a => a.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var stud = new Teacher { Id = id };
            _context.Remove(stud);
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task Post(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        public async Task Put(Teacher teacher)
        {
            _context.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
