using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class Medicine : MedicineAsset
    {
        [Required]
        public string NRMD { get; set; }
        [Required]
        public string NameMedicine { get; set; }
        [Required]
        public string DeweyIndex { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
