using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using _25DH110083_MyStore.Models;

namespace _25DH110083_MyStore.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.TotalProducts = db.Products.Count();
            ViewBag.TotalCategories = db.Categories.Count();
            ViewBag.TotalCustomers = db.Customers.Count();
            ViewBag.TotalOrders = db.Orders.Count();

            var rows = new List<object[]>();
            rows.Add(new object[] { "Danh mục", "Số sản phẩm" });
            foreach (var c in db.Categories.ToList())
            {
                rows.Add(new object[] { c.CategoryName, c.Products.Count });
            }
            ViewBag.ChartJson = new JavaScriptSerializer().Serialize(rows);

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}