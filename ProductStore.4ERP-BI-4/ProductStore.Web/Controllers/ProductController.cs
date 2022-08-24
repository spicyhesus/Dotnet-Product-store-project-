using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductStore.Domain.Entities;
using ProductStore.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Web.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService prodService;
        readonly ICategoryService catService;
        public ProductController(IProductService prodService, ICategoryService catService)
        {
            this.prodService = prodService;
            this.catService = catService;
        }
        public ActionResult Index2()
        {
            return View(prodService.GetAll().OrderByDescending(p=>p.Price));
        }

        // GET: ProductController
        public ActionResult Index(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
                return View(prodService.GetMany(p=>p.Name.Contains(filter)));
            return View(prodService.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.mycategories = new SelectList(catService.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,IFormFile file)
        {
            try
            {
                //ajout dans la base
                product.ImageURL3 = file.FileName;
                prodService.Add(product);
                prodService.Commit();

                //ajout de l'image dans le dossier uploads
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                    file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Product p = prodService.GetById(id);
            if (p == null)
                return NotFound();

            ViewBag.mycategories = new SelectList(catService.GetAll(), "CategoryId", "CategoryName",p.CategoryId);
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {
            try
            {
                prodService.Update(p);
                prodService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Product p = prodService.GetById(id);
            if (p == null)
                return NotFound();
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Product p = prodService.GetById(id);
                prodService.Delete(p);
                prodService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
