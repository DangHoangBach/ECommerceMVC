using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ECommerceMVC.Helpers;

namespace ECommerceMVC.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                var cart = HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
                return View("CartPanel", new CartModel
                {
                    Quantity = cart.Sum(p => p.SoLuong),
                    Total = cart.Sum(p => p.ThanhTien)
                });
        }
    }
}
