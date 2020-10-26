using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class BookSubscriptionModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool IsActive { get; set; }

    }
}