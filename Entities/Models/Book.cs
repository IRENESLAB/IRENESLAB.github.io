using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Book :BookModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}