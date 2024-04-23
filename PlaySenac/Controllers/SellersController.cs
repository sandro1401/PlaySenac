using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using PlaySenac.Data;
using PlaySenac.Models;

namespace PlaySenac.Controllers
{
    public class SellersController : Controller
    {
        private readonly PlaySenacContext _context;

        public SellersController(PlaySenacContext context) { 
            _context = context;
        }

        public IActionResult Index() { 
            var sellers = _context.Seller.Include("Department").ToList();
            return View(sellers);
        }

        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Seller seller) {
            /*Testa se foi passado um objeto vendedor*/
            if (seller == null) { 
                /*Retorna não página não encontrada*/
                return NotFound();
            }
            seller.Department = _context.Department.FirstOrDefault();
            seller.DepartmentId = seller.Department.Id;

            /*Adicionar o vendedor no banco de dados*/
            _context.Add(seller);
            /*Confirma/PersistenceMode as adição do vendedor no banco*/
            _context.SaveChanges();
            /*Redireciona para a action index*/
            return RedirectToAction("Index");
        }

    }
}
