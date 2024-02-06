using Microsoft.AspNetCore.Mvc;
using app01.Data;

namespace app01.Controllers;

[ApiController]
[Route("[controller]")]
public class PositionsController : ControllerBase {

    private readonly DataService _db;

    public PositionsController(DataService db) {
        _db = db;
    }

    [HttpGet(Name = "GetPositions")]
    public IEnumerable<Position> Get() {
        return _db.Positions.ToArray();
    }

    [HttpPost]
    public IActionResult Post(Position position) {
        _db.Positions.Add(position);
        _db.SaveChanges();
        var res = _db.Positions.Single(e => e.Id == position.Id);
        return CreatedAtAction(nameof(Get), new { id = res.Id}, res);
    }

    [HttpPut("{id}")]
    public Position Put(long id, Position pos) {
        var act = _db.Positions.Find(id);
        if(act == null) { return pos; }
        act.Name = pos.Name;
        _db.SaveChanges();
        var res = _db.Positions.Single(e => e.Id == id);
        return res;
    }

    [HttpDelete("{id}")]
    public int Delete(long id) {
        var act = _db.Positions.Find(id);
        if(act == null) { return 0; }
        _db.Positions.Remove(act);
        var affectedRecords = _db.SaveChanges();
        return affectedRecords;
    }    

}