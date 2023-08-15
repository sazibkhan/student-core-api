using Microsoft.EntityFrameworkCore;
using student_core_api.Model;

namespace student_core_api.Data
{
    public class DataContext :DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("StudentAPIDb");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        

        public DbSet<Student> Students{ get; set; }
        public DbSet<Teacher> teachercs{ get; set; }
    }
}
