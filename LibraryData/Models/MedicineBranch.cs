using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class MedicineBranch
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<MedicineAsset> MedicineAssets { get; set; }

        public string ImageUrl { get; set; }
    }
}
