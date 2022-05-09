﻿using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IOrderStorage _orderStorage;
        public AdminController(IProductStorage productStorage, IOrderStorage orderStorage)
        {
            _productStorage = productStorage;
            _orderStorage = orderStorage;
        }
        public IActionResult Orders()
        {
            var orders = _orderStorage.GetOrderData();
            return View(orders);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = _productStorage.GetProductData();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productStorage.AddProduct(product);
                return RedirectToAction("Products");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productStorage.EditProduct(product);
                return RedirectToAction("Products");
            }
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            _productStorage.RemoveProduct(id);
            return RedirectToAction("Products"); ;
        }
    }
}
