using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class UserBookModel
    {

        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }

    }
}