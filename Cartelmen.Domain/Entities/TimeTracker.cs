using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cartelmen.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Domain.Entities
{
    public class TimeTrack : ISoftDeletable
    {
        public int Id { get; set; }

        [Required] [Column(TypeName = "date")]
        public DateOnly WorkDate { get; set; }

        [Required] [Precision(4, 2)] 
        public decimal WorkHours { get; set; } = 0m;


        public Spot Spot { get; set; }
        public int SpotId { get; set; }

        public Person Person { get; set; }
        public Guid PersonId { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
