using Microsoft.AspNetCore.Mvc;
using FirstMvcWebApp.Data;
using System.Drawing;
using FirstMvcWebApp.Dto;
using Microsoft.EntityFrameworkCore;
namespace FirstMvcWebApp.Controllers
{
    public class DashBoardController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {

            // Select => For every row, create something

            var list = context.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                Color = x.Color,
                Description = x.Description,
                Price = x.Price,
                ProductName = x.ProductName
            }).ToList();

            //ToList() => Execute the query and return the result as a list

            return View(list);
        }

        public IActionResult ProductForm() => View();

        [HttpGet]
    public IActionResult UpdateProduct( int id)
        {
            var data = context.Products.Select(x => new ProductDto { Id = x.Id,
                ProductName = x.ProductName,    
                Color = x.Color,
                Description = x.Description,
                Price = x.Price,
               
            }).FirstOrDefault(x => x.Id == id);
            return View("UpdateProductForm", data);
        }

        public async Task<IActionResult> CreateProduct(ProductDto dto)
        {
            if (dto == null)
            {
                ViewBag.ErrorMessage = "Product data is required.";
                return View("ProductForm");
            }
            context.Products.Add(new Models.Product
            {
                Color = dto.Color,
                Description = dto.Description,
                Price = dto.Price,
                ProductName = dto.ProductName
            });

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int productid)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == productid);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /*
        public IActionResult DeleteProduct(int ProductId)
        {
            var product = context.Products.Find(ProductId);
            context.Remove(ProductId);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        */

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(ProductDto dto)
        {
             if (dto == null)
            {
                ViewBag.ErrorMessage = "Product data is required.";
                return View("UpdateProductForm");
            }

            var data = context.Products.FirstOrDefault(x => x.Id == dto.Id);
            data.Price = dto.Price;
            data.ProductName = dto.ProductName;
            data.Color = dto.Color;
            data.Description = dto.Description;

            context.Products.Update(data);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}








