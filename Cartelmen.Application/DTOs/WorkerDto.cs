namespace Cartelmen.Application.DTOs;
public class WorkerDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public decimal PayRate { get; set; } = default!;
    public DateOnly? HiringDate { get; set; }

}
