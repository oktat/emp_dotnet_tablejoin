using Microsoft.AspNetCore.Mvc;
using app01.Data;

namespace app01.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly DataService _db;

    public EmployeeController(DataService db) {
        _db = db;
    }

    [HttpGet(Name = "GetEmployees")]
    public IEnumerable<Employee> Get() {
        return _db.Employees.ToArray();
    }

    [HttpPost]
    public IActionResult Post(Employee employee) {
        _db.Employees.Add(employee);
        _db.SaveChanges();
        var res = _db.Employees.Single(e => e.Id == employee.Id);
        return CreatedAtAction(nameof(Get), new { id = res.Id}, res);
    }

    [HttpPut("{id}")]
    public Employee Put(long id, Employee emp) {
        var act = _db.Employees.Find(id);
        if(act == null) { return emp; }
        act.Name = emp.Name;
        act.City = emp.City;
        act.Salary = emp.Salary;
        _db.SaveChanges();
        var res = _db.Employees.Single(e => e.Id == id);
        return res;
    }

    [HttpDelete("{id}")]
    public int Delete(long id) {
        var act = _db.Employees.Find(id);
        if(act == null) { return 0; }
        _db.Employees.Remove(act);
        var affectedRecords = _db.SaveChanges();
        return affectedRecords;
    }    

}