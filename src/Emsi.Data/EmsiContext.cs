using Emsi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Emsi.Data
{
    public class EmsiContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; } = default!;
        public DbSet<Meta> Metas { get; set; } = default!;


        public EmsiContext(DbContextOptions options) : base(options)
        {

        }
    }
}
