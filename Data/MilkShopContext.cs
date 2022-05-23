using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkShop.Models;

namespace MilkShop.Data
{
    public class MilkShopContext : DbContext
    {
        public MilkShopContext (DbContextOptions<MilkShopContext> options)
            : base(options)
        {
        }

        public DbSet<MilkShop.Models.Milk> Milk { get; set; }
    }
}
