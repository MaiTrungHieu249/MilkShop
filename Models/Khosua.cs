using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MilkShop.Data;
using MilkShop.Models;
using System;
using System.Linq;
namespace MilkShop.Models
{
    public static class Khosua
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MilkShopContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<MilkShopContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.Milk.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }
                context.Milk.AddRange(
                new Milk
                {
                    Title = "Sữa Bò",
                    ReleaseDate = DateTime.Parse("2022-03-01"),
                    Genre = "Koita",
                    Price = 11.98M,
                    Rating= "15"
                },
                new Milk
                {
                    Title = "Sữa Vinamilk",
                    ReleaseDate = DateTime.Parse("2022-03-01"),
                    Genre = "Vinamilk",
                    Price = 18.59M,
                    Rating = "16"
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}
