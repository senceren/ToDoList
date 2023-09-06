using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Data;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ToDoItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<ToDoItem> GetToDoItems()
        {
            return _db.ToDoItems.OrderBy(x => x.Done).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetToDoItem(int id)  // hem action result döndğrmek hem de todoıtem göndermek için
        {
            var item = _db.ToDoItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<ToDoItem> PostToDoItem(ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                _db.Add(item);
                _db.SaveChanges();
                return CreatedAtAction(nameof(GetToDoItems), new { id = item.Id }, item); // 201 durum koduyla döndürmek ve buna sonradan erişmek için headerda url bilgisine erişebilmek için createdtoaction dedik. 
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoItem(int id)
        {
            var item = _db.ToDoItems.Find(id);

            if (item == null)
                return NotFound();

            _db.Remove(item);
            _db.SaveChanges();

            return Ok(); // return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutToDoItem(int id, ToDoItem item)
        {
            if (id != item.Id) // id aldığımız itemin ıdsi ile eşit değilse
                return BadRequest();

            if (!_db.ToDoItems.Any(x => x.Id == id))  // gönderilen id'li item db içinde yoksa
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(item);
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);

        }
    }
}
