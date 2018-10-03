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

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscles { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Split> Splits { get; set; }
        public DbSet<SplitDay> SplitDays { get; set; }
        public DbSet<RepScheme> RepSchemes { get; set; }

        

    }
}
