using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace GainzWebAPI.Models
{
    public class GainzDBContext : DbContext
    {
        public GainzDBContext(DbContextOptions<GainzDBContext> options)
            : base(options)
        {

        }

        public DbSet<Exercise> exercises { get; set; }
        public DbSet<ExerciseMuscle> exerciseMuscles { get; set; }
        public DbSet<Muscle> muscles { get; set; }
        public DbSet<Split> splits { get; set; }
        public DbSet<SplitDay> splitDays { get; set; }

        

    }
}
