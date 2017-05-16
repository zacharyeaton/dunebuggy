using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DuneBuggy.Businesslayer.Models;
using DuneBuggy.Datalayer.UnitOfWork;

namespace DuneBuggy.Controllers
{
    public class ProductsController : BaseController
    {
        UnitOfWork _context = new UnitOfWork();

        // GET: Products
        public ActionResult Index()
        {           
            var products = _context.Product.GetAll().ToList();                       

            return View(products);
        }

        public ActionResult Create()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "users");
            }            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {            
            if (ModelState.IsValid)
            {
                if (file != null)
                {                    
                    var filename = Request.Files[0].FileName;
                    var filepath = Path.Combine(Server.MapPath("~/Images"), filename);
                    var product_image = string.Concat("/Images/", filename);
                    if (MimeMapping.GetMimeMapping(filename).StartsWith("image/"))
                    {                        
                        file.SaveAs(filepath);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error- Uploaded incorrect image type");
                        return View(product);
                    }                    

                    var newProduct = new Product
                    {
                        product_name = product.product_name,
                        product_description = product.product_description,
                        product_cost = product.product_cost,
                        product_image = product_image,
                        product_added = DateTime.Now
                    };
                    _context.Product.Add(newProduct);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("index", "products");
            }
            var product = _context.Product.GetSingle(p => p.product_id == id);           
               
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("login", "users");
            }

            if (id == 0)
            {
                return RedirectToAction("index", "products");
            }
            var product = _context.Product.GetSingle(p => p.product_id == id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var product_image = "";
                if (file != null)
                {                    
                    var filename = Request.Files[0].FileName;
                    var filepath = Path.Combine(Server.MapPath("~/Images"), filename);
                    product_image = string.Concat("/Images/", filename);
                    if (MimeMapping.GetMimeMapping(filename).StartsWith("image/"))
                    {
                        file.SaveAs(filepath);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error- Uploaded incorrect image type");
                        return View(product);
                    }                    
                }
                
                if (product.product_id > 0)
                {
                    Product editedProduct = _context.Product.GetSingle(b => b.product_id == product.product_id);
                    editedProduct.product_name = product.product_name;
                    editedProduct.product_description = product.product_description;
                    editedProduct.product_cost = product.product_cost;
                    editedProduct.product_image = product_image == "" ? product.product_image : product_image;
                    editedProduct.product_added = DateTime.Now;

                    _context.SaveChanges();
                }
                return RedirectToAction("Index");               
                
            }
            return View();
        }       
    }
}