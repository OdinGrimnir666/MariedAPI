using System.Data;
using System.Text.Json.Serialization;

namespace Core.Models;

public class Person
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public bool Married { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }

    public Person(string name, DateOnly dateOfBirth, bool married, string phone, decimal salary)
    {
        this.DateOfBirth = dateOfBirth;
        this.Name = name;
        this.Married = married;
        this.Phone = phone;
        this.Salary = salary;
    }

    public void Update(Person person)
    {
        this.DateOfBirth = person.DateOfBirth;
        this.Name = person.Name;
        this.Married = person.Married;
        this.Phone = person.Phone;
        this.Salary = person.Salary;
    }
}