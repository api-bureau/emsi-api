using Emsi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Emsi.Data
{
    public class EmsiContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; } = null!;

        public string DbPath { get; private set; }

        public EmsiContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
