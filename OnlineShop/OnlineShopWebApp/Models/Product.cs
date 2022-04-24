﻿using System;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public Guid GuidId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public Product () { } // Empty ctor for XML serializing.
        
        public Product(string id, string imagePath, string name, decimal cost, string description)
        {
            Id = id;
            ImagePath = imagePath;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
}
