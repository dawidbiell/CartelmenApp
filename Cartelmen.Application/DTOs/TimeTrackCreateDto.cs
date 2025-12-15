namespace Cartelmen.Application.DTOs;

public class TimeTrackCreateDto
{
    
    public int SpotPersonId { get; set; }
    public DateOnly Date { get; set; }
    public decimal WorkTime { get; set; }
    public decimal? PayRate { get; set; }
}