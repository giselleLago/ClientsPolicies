using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientsPolicies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsPolicies.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Clients Client { get; set; }
        public ClientsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Client = new Clients();
            if (id == null)
            {
                return View(Client);
            }
            Client = _db.Clients.FirstOrDefault(u => u.Id == id);
            if (Client == null)
            {
                return NotFound();
            }
            return View(Client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Client.Id == 0)
                {
                    //create
                    _db.Clients.Add(Client);
                }
                else
                {
                    _db.Clients.Update(Client);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Client);
        }

        #region Api Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Clients.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var clientFromDb = await _db.Clients.FirstOrDefaultAsync(i => i.Id == id);
            if (clientFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Clients.Remove(clientFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}