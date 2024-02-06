using System.ComponentModel.DataAnnotations.Schema;

namespace app01;

public class Employee {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public double Salary { get; set; }
    public int PositionId { get; set; }
    
    [ForeignKey("PositionId")]
    public Position Position { get; set; }
}