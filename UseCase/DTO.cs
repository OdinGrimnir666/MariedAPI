namespace Infrastructure;

public class PersonDTO
{
    public string Name { get; set; }
    [CsvHelper.Configuration.Attributes.Name("Date of Birth")]
    public DateOnly DateOfBirth { get; set; }
    public bool Married { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }
}
