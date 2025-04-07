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
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
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

    public async Task<Product> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<List<Product>> GetAllProductAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductAsync(int id)
    {
        return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
