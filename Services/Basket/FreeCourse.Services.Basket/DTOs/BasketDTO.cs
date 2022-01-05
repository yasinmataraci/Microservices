using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.DTOs
{
    public class BasketDTO
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDTO> BasketItem { get; set; }
        public decimal TotalPrice { get => BasketItem.Sum(x => x.Price * x.Quantity); }
    }
}
