using MeuProjeto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MeuProjeto.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService =  sellerService;
        }

        public IActionResult Index()
        {

            var list = _sellerService.FindAll();

            return View(list);
        }
    }
}
