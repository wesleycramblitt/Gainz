using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class RepSchemeSet
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int Reps { get; set; }

        public int Percent1RM { get; set; }

        public int RestInterval { get; set; }
    }
}
