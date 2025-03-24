﻿using EShop.Domain.Models;
using EShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Seeders;

public class EShopeeder(DataContext context) : IEShopSeeder
{
    public async Task Seed()
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product {Name = "Cobi", Ean ="1234"},
                new Product {Name = "Duplo", Ean ="431"},
                new Product {Name = "Lego", Ean ="12212"}
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}