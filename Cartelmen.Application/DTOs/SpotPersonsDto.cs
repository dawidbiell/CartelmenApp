using System.ComponentModel.DataAnnotations;

namespace Cartelmen.Application.DTOs;
public class SpotPersonsDto
{
    public SpotDto Spot { get; set; }
    public IEnumerable<PersonDto> Persons { get; set; }
    
}
