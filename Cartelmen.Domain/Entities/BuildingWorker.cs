using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartelmen.Domain.Entities
{
    public class BuildingWorker
    {
        [Key]
        public int Id { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public Guid WorkerId { get; set; }
        public Worker Worker { get; set; }

        public DateTime AssignmentDate { get; set; }
    }
}
