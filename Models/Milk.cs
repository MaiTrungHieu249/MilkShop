using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace MilkShop.Models
{
    public class Milk
    {
        public int Id { get; set; }
        [Display(Name = "Tên sữa")]
        public string Title { get; set; }
        [Display(Name = "Ngày sản xuất")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Hãng sữa")]
        public string Genre { get; set; }
        [Display(Name ="số lượng")]
        public string Rating { get; set; }
        [Display(Name = "Giá bán")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}