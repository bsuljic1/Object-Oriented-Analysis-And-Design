using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EBANK.Models;
using EBANK.Models.AdministratorRepository;
using EBANK.Data;

namespace EBANK.Controllers
{
    public class AdministratorHomeController : Controller
    {
        private IAdministratori _administratori;
        private Administrator administrator;

        public AdministratorHomeController(OOADContext context)
        {
            _administratori = new AdministratoriProxy(context);
        }

        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Administrator")
                administrator = await _administratori.DajAdministratora(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            return View(administrator);
        }
    }
}
