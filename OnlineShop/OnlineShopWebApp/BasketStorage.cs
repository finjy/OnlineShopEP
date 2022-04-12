﻿using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class BasketStorage: IBasketStorage
    {
        private List<Basket> baskets = new List<Basket>();

        public List<Basket> Baskets
        {
            get
            {
                return baskets;
            }
        }

        public void AddProduct(Product product)
        {
            var basket = Baskets.Where(basket => basket.Product.Id == product.Id)
                                              .FirstOrDefault();
            if (basket == null)
            {
                baskets.Add(new Basket(product));
            }
            else
            {
                basket.Quantity++;
            }
        }

        public decimal GetTotalSum()
        {
            return Baskets.Sum(basket => basket.Product.Cost * basket.Quantity);
        }
    }
}
