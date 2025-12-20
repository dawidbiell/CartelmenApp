using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartelmen.Domain.Entities
{
    public class SpotPerson
    {
        [Key]
        public int Id { get; set; }

        public int SpotId { get; set; }
        public Spot Spot { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public DateTime? AssignmentDate { get; set; }
        
        [Column(TypeName = "money")]
        public decimal PayRate { get; set; }
    }
}
