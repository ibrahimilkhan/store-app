using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class CardLine
{
    public int Id { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}