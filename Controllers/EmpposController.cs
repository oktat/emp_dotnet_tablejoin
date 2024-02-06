using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app01.Data;

namespace app01.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpposController : ControllerBase {
    private readonly DataService _db;
    public EmpposController(DataService db) {
        _db = db;
    }
    [HttpGet]
    public IEnumerable<EmployeePositionViewModel> GetEmployePositons() {
         var emppos = _db.Employees
        .Include(e => e.Position)
        .Select(e => new EmployeePositionViewModel {
            Id = e.Id,
            Name = e.Name,
            City = e.City,
            Salary = e.Salary,
            Position = e.Position.Name
        })
        .ToList()
        ;
        return emppos;
    }
}