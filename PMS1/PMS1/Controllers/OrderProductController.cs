using PMS1.DTOs;
using PMS1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS1.Controllers
{
    public class OrderProductController : Controller
    {
        //Convert
        public static OrderProduct Convert(OrderProductDTO o)
        {
            return new OrderProduct()
            {
                Id = o.Id,
                PId = o.PId,
                OId = o.OId,
                Qty = o.Qty,
                UnitPrice = o.UnitPrice
            };
        }

        public static OrderProductDTO Convert(OrderProduct o)
        {
            return new OrderProductDTO()
            {
                Id = o.Id,
                PId = o.PId,
                OId = o.OId,
                Qty = o.Qty,
                UnitPrice = o.UnitPrice
            };
        }
        public static List<OrderProductDTO> Convert(List<OrderProduct> ords)
        {
            var list = new List<OrderProductDTO>();
            foreach (var item in ords)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        PMSEntities db = new PMSEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Orders()
        {
            var data = db.Orders.ToList();
            return View(OrderController.Convert(data));
        }

        //Order details
        public ActionResult Od(int id)
        {
            var data = (from order in db.OrderProducts
                        where order.OId == id
                        select order).ToList();

            return View(Convert(data));
        }

        public ActionResult Accept(int id)
        {
            var order = db.Orders.Find(id);
            var orderProducts = order.OrderProducts;  //Order related OrderProduct er collection gola chole asteche
            foreach (var item in orderProducts)
            {
                item.Product.Qty -= item.Qty;
                //var p = db.Products.Find(item.PId);
                //p.Qty -= item.Qty;
            }
            order.Status = "Processing";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " processing";
            return RedirectToAction("Orders");

        }
        public ActionResult Decline(int id)
        {
            var order = db.Orders.Find(id);
            order.Status = "Declined";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " declined";
            return RedirectToAction("Orders");
        }      

    }
}