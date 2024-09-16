using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class CartLine
{
    public int Id { get; set; }
    public required Product Product { get; set; }
    public int Quantity { get; set; }
}