﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class UserBook
    {

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        
        public bool IsActive { get; set; } 

    }
}