using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExerciceEfCore.Models;

namespace ExerciceEfCore.Data
{
    public class ExerciceEfCoreContext : DbContext
    {
        public ExerciceEfCoreContext (DbContextOptions<ExerciceEfCoreContext> options)
            : base(options)
        {
        }

        public DbSet<ExerciceEfCore.Models.TodoTask> TodoTask { get; set; } = default!;
    }
}
