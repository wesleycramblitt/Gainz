using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class SplitDay
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set;}

        public bool IsRest { get; set;}

        public List<SplitDayMuscle> SplitDaysMuscles { get; set;}
    }
}
