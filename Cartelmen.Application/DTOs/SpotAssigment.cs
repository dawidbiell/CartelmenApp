namespace Cartelmen.Application.DTOs;


public class SpotAssigmentDto
{
    public Guid PersonId { get; set; }

    public DateTime? AssignmentDate { get; set; }
    
    public decimal? PayRate { get; set; }
    
}