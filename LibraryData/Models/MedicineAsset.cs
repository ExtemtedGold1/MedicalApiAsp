﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class MedicineAsset
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public Status Status{ get; set; }
        [Required]
        public decimal Cost { get; set; }
        
        public string ImageUrl { get; set; }
        
        public int NumberOfCopies { get; set; }
        
        public virtual MedicineBranch Location { get; set; }

    }
}
