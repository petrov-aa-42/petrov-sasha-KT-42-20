using petrovsanyaKT_42_20.Models;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace petrovsanyaKT_42_20.Database
{
    public class PrepodDbContext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Kafedra> Kafedra { get; set; }
        public DbSet<Prepod> Prepod { get; set; }
        public DbSet<Degree> Degree { get; set; }

        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options)
        {
        }
    }
}
