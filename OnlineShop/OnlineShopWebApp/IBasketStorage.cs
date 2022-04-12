﻿using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IBasketStorage
    {
        List<Basket> Baskets { get; }
        void AddProduct(Product product);
        decimal GetTotalSum();
    }
}