﻿using System;
using System.Linq;
using System.Web.Mvc;
using DKITMusicStore.Models;

namespace DKITMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        DKITMusicStoreEntities storeDB = new DKITMusicStoreEntities();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            Order o = storeDB.Orders.SingleOrDefault(
                or => or.OrderId == id &&
                or.Username == User.Identity.Name);

            if (o!=null)
            {
                return View(o);
            }
            else
            {
                return View("Error");
            }
        }
    }
}