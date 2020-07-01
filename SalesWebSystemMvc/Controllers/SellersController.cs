using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebSystemMvc.Models;
using SalesWebSystemMvc.Services;

namespace SalesWebSystemMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.InsertDB(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}