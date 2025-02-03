using JQ_prj1.Models;
using Microsoft.EntityFrameworkCore;

namespace JQ_prj1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        // DbSets for the models
        public DbSet<BlogModel> TL_Blog { get; set; }
        public DbSet<UserModel> TL_User { get; set; }
        public DbSet<BlogCommentModel> TL_BlogComment { get; set; }

    }
}
