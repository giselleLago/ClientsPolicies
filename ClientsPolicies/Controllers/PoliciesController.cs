using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientsPolicies.Models;
using ClientsPolicies.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientsPolicies.Controllers
{
    public class PoliciesController : Controller
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public Policies Policies { get; set; }
        public PoliciesController(ApplicationDbContext db)
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
            var dataA = dataAccess.ExtractPoliciesData();
            foreach (var item in dataA)
            {
                _db.Policies.Add(item);
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
                return Json(new { data = await _db.Policies.ToListAsync() });
            }
            return Json(new { data = await _db.Policies.ToListAsync() });
        }
        #endregion
    }
}