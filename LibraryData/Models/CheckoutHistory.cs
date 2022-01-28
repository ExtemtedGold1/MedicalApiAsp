using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class CheckoutHistory
    {
        public int Id { get; set; }
        [Required]
        public MedicineAsset MedicineAsset { get; set; }
        [Required]
        public MedicineCard MedicineCard { get; set; }

        [Required]
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
    }
}
