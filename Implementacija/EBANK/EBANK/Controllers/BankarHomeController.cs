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
using EBANK.Models.BankarRepository;

namespace EBANK.Controllers
{
    public class BankarHomeController : Controller
    {
        private IBankari _bankari;
        private Bankar bankar;

        public BankarHomeController(OOADContext context)
        {
            _bankari = new BankariProxy(context);
        }

        public async Task<IActionResult> Index()
        {
            var userId = Request.Cookies["userId"];
            var role = Request.Cookies["role"];

            if (userId != null && role == "Bankar")
                bankar = await _bankari.DajBankara(userId);
            else
                return RedirectToAction("Index", "Login", new { area = "" });

            return View(bankar);
        }
    }
}
