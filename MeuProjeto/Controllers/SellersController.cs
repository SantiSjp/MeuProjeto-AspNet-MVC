﻿using MeuProjeto.Models;
using MeuProjeto.Models.ViewModels;
using MeuProjeto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MeuProjeto.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService  =  sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {

            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {

            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };

            return View(viewModel);
        }

        // Informa método Post
        [HttpPost]
        // Previne ataque CSRF
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
