﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(64)]
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public DateOnly? StartDate { get; set; }

        public Address Address { get; set; } = default!;
        public IList<Worker> Workers { get; set; } = new List<Worker>();


    }
}
