

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class BookModel
    {
        [Column(TypeName="varchar(100")]
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal PurchasePrice { get; set; } 
    }
}