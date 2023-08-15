using Microsoft.AspNetCore.Mvc;
using student_core_api.Data;
using student_core_api.Model;

namespace student_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {

       
            private DataContext _context;

            public TeacherController(
                DataContext context)
            {
                _context = context;
            }





            [HttpGet]
            public IEnumerable<Teacher> GetAll()
            {
                return _context.teachercs;
            }

            [HttpGet("{id}")]
            public Teacher GetById(int id)
            {
                return getTeacher(id);
            }



            [HttpPost]
            public void CreateTeacher(Teacher teacher)
            {
                // save user
                _context.teachercs.Add(teacher);
                _context.SaveChanges();
            }


            [HttpPut]
            public void Update(int id, Teacher model)
            {
                var std = getTeacher(id);

            //// validate
            if (model.id != std.id && _context.teachercs.Any(x => x.id == model.id))
            {
                throw new KeyNotFoundException("Student with the Name '" + model.id + "' already exists");
            }



            _context.teachercs.Update(std);
                _context.SaveChanges();
            }
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var std = getTeacher(id);
                _context.teachercs.Remove(std);
                _context.SaveChanges();
            }


            private Teacher getTeacher(int id)
            {
                var std = _context.teachercs.Find(id);
                if (std == null) throw new KeyNotFoundException("Student not found");
                return std;
            }
        
    }
}
