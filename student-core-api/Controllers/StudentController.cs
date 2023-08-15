using Microsoft.AspNetCore.Mvc;
using student_core_api.Data;
using student_core_api.Model;

namespace student_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private DataContext _context;

        public StudentController(
            DataContext context)
        {
            _context = context;
        }





        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return getStudent(id);
        }



        [HttpPost]
        public void CreateStudent(Student student)
        {
            // save user
            _context.Students.Add(student);
            _context.SaveChanges();
        }


        [HttpPut]
        public void Update(int id, Student model)
        {
            var std = getStudent(id);

            // validate
            if (model.Id != std.Id && _context.Students.Any(x => x.Id == model.Id))
            {
                throw new KeyNotFoundException("Student with the Name '" + model.Id + "' already exists");
            }



            _context.Students.Update(std);
            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var std = getStudent(id);
            _context.Students.Remove(std);
            _context.SaveChanges();
        }


        private Student getStudent(int id)
        {
            var std = _context.Students.Find(id);
            if (std == null) throw new KeyNotFoundException("Student not found");
            return std;
        }
    }

}
