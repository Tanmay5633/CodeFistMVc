using Microsoft.EntityFrameworkCore;
using CodeFistMVc.Models;

namespace CodeFistMVc.Models
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions options):base(options)
        {
            

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<CodeFistMVc.Models.Login> Login { get; set; } = default!;
    }
}
