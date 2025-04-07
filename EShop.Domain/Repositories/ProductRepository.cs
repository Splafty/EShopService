using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = GetById(id);

        _context.Remove(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product GetById(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            throw new Exception($"Product with ID {id} not found.");
        return product;
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    //IEnumerable<Product> IProductRepository.GetAll()
    //{
    //    throw new NotImplementedException();
    //}
}
