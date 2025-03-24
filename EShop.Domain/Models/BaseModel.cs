﻿namespace EShop.Domain.Models;

public class BaseModel
{
    public Boolean Deleted { get; set; } = false;
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public Guid Created_by { get; set; }
    public DateTime? Updated_at { get; set; } = DateTime.UtcNow;
    public Guid? Updated_by { get; set; }
}
