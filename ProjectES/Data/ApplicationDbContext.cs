using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectES.Models;

namespace ProjectES.Data
{
	public class ApplicationDbContext : IdentityDbContext<UserDetails>
	{
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assay> Assays { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		
       
    }
}