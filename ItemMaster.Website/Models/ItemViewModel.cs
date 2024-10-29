using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.Website.Models
{
    public class ItemViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Code Required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }


        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Numeric")]
        public decimal Price { get; set; }


        public string Description { get; set; }
    }
}
