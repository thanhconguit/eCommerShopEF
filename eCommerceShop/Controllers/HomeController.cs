﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eCommerceShop.Models;
using eCommerceShop.Data.Repository;

namespace eCommerceShop.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository _categoryRepositoty;
        private IProductRepository _productRepository;

        public HomeController(ICategoryRepository categoryRepositoty, IProductRepository productRepository)
        {
            _categoryRepositoty = categoryRepositoty;
            _productRepository = productRepository;
        }
       

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                categoriesList = await _categoryRepositoty.GetAll(),
                productsList = (await _categoryRepositoty.FindByIdAsync(1)).Products
            };
            return View(model);
        }
        public async Task<IActionResult> ItemList(int id)
        {
            var model = new HomeViewModel
            {
                categoriesList = await _categoryRepositoty.GetAll(),
                productsList = (await _categoryRepositoty.FindByIdAsync(id)).Products           
            };

            return View("Index", model);
        }
        public async Task<IActionResult> ItemDetail( int id)
        {
            var model = new ProductViewModel
           { 
                categoriesList = await  _categoryRepositoty.GetAll(),
                product = await _productRepository.FindByIdAsync(id)            
            };
            return View(model);


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
