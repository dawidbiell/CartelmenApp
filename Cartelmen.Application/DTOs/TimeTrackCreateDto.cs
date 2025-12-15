namespace Cartelmen.Application.DTOs;

public class TimeTrackCreateDto
{
    
    public int SpotPersonId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public decimal WorkTime { get; set; }
    public decimal? PayRate { get; set; }
}