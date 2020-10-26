using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}