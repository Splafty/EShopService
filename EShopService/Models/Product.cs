using System.ComponentModel;

namespace EShopService.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Ean { get; set; } = default!;
    public decimal Price {  get; set; }
    public int Stock { get; set; }
    public string Sku { get; set; } = default!;
    public Category Category { get; set; } = default!;
    public Boolean Deleted { get; set; }
    public DateTime Created_at { get; set; }
    public Guid Created_by { get; set; }
    public DateTime? Updated_at { get; set; }
    public Guid? Updated_by { get; set; }
}
