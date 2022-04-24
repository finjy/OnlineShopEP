﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IFavoritesStorage _favoritesStorage;

        public FavoritesController(IProductStorage productStorage, IFavoritesStorage favoritesStorage)
        {
            _productStorage = productStorage;
            _favoritesStorage = favoritesStorage;
        }
        public IActionResult Index()
        {
            var favoritesList = _favoritesStorage.TryGetByUserId(Constants.UserId);
            if (favoritesList == null || favoritesList.Products.Count == 0)
            {
                return View("Empty");
            }
            return View(favoritesList);
        }

        public IActionResult Add(string productId)
        {
            var product = _productStorage.TryGetProduct(productId);
            _favoritesStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string productId)
        {
            var product = _productStorage.TryGetProduct(productId);
            _favoritesStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _favoritesStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}