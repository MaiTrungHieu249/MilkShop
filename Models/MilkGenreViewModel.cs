using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MilkShop.Models
{
    public class MilkGenreViewModel
    {
        public List<Milk>? Milks { get; set; }
        public SelectList? Genres { get; set; }
        public string? MilkGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
