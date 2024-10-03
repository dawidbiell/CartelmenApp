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


        public Building Building { get; set; }
        public int BuildingId { get; set; }

        public Worker Worker { get; set; }
        public Guid WorkerId { get; set; }


        public bool IsDeleted { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
