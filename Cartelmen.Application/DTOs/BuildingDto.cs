using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.DTOs;
public class BuildingDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? StartDate { get; set; }

    public string? Country { get; set; } 
    public string? City  { get; set; } 
    public string? Street  { get; set; }
    public string? PostalCode { get; set; }
    
}
