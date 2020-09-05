﻿using MeuProjeto.Models;
using MeuProjeto.Models.ViewModels;
using MeuProjeto.Services;
using MeuProjeto.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            // Validação no lado do servidor
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel
                {
                    Seller = seller,
                    Departments = departments
                };
                return View(viewModel);
            }
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID is NULL" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found" });
            }

            return View(obj);
        }

        // Informa método Post
        [HttpPost]
        // Previne ataque CSRF
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID is NULL" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID is NULL" });
            }

            // Id.value porque id é opcional "int?"
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not found" });
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj,Departments = departments };

            return View(viewModel);
        }

        // Informa método Post
        [HttpPost]
        // Previne ataque CSRF
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {

            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel
                {
                    Seller = seller,
                    Departments = departments
                };
                return View(viewModel);
            }

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID mismatch" });
            }

            try
            {
                _sellerService.Update(seller);
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}
