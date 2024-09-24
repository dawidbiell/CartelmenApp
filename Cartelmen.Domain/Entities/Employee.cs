namespace Cartelmen.Domain.Entities
{
    public class Employee
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime HiringDate { get; set; }
        public decimal PayRate { get; set; }
        public ContactDetails Contact { get; set; } = default!;
    }
}
