using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientsPolicies.Models;
using ClientsPolicies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsPolicies.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _db;
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

        private void LoadTable()
        {
            DataAccess dataAccess = new DataAccess();
            var dataA = dataAccess.ExtractClientsData();
            foreach (var item in dataA)
            {
                _db.Clients.Add(item);
                _db.SaveChanges();
            }
        }

        #region Api Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (_db.Clients.Count() == 0)
            {
                LoadTable();
                return Json(new { data = await _db.Clients.ToListAsync() });
            }
            return Json(new { data = await _db.Clients.ToListAsync() });
        }
        #endregion
    }
}