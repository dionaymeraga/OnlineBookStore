﻿using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreWeb.Models
{

    
    public class Category

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
