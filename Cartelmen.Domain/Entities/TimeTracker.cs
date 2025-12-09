using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cartelmen.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Domain.Entities
{
    public class TimeTracker : ISoftDeletable
    {
        [Required] [Column(TypeName = "date")]
        
        public DateOnly WorkDate { get; set; }
        
        [Required] [Precision(4, 2)] 
        public decimal WorkTime { get; set; } = 0m;
        
        [Column(TypeName = "money")]
        public decimal PayRate { get; set; }
        
        public bool IsSubmitted { get; set; }
        
        public string? UpdatedBy { get; set; }
        
        public DateTime? UpdatedAtUtc { get; set; }
        
        
        public SpotPerson SpotPerson { get; set; }
        public int SpotPersonId { get; set; }

        // soft delete
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
