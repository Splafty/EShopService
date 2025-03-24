using EShop.Domain.Models;
using EShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Seeders;

public interface IEShopSeeder
{
    Task Seed();
}