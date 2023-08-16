using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parmacy.Shaar.Data;
using Parmacy.Shaar.Models;
using Parmacy.Shaar.Models.ViewModels;

namespace Parmacy.Shaar.Controllers
{
    public class BusinessController : Controller
    {
        readonly ApplicationDbContext db;
        public BusinessController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Buy(int? receipt = 0)
        {
            if (HttpContext.Session.GetInt32("UID") == null)
            {
                HttpContext.Session.SetString("Redirect", "Business/Buy");
                return RedirectToAction(nameof(UserController.Login), "User");
            }
            if (receipt == 0)
            {
                try
                {
                    receipt = db.buyInvoices.Max(s => s.No) + 1;
                }
                catch { receipt = 1; }
            }
            ViewBag.Items = new SelectList(await db.items.ToListAsync(), "Item_Id", "Name");
            ViewBag.Delegates = new SelectList(await db.delegates.ToListAsync(), "ID", "Name");
            ViewBag.Receipt = receipt;
            ViewBag.invoice=await db.buyInvoices.Where(p => p.No == receipt).Select(p=>new ReceiptVM
            {
                Date=p.Date,
                Delegate=p.Delegate.Name,
                Employee=p.Employee.Name,
                Items=db.items_purchase.Where(s=>s.Receipt_No==receipt).Select(s=>new ItemPriceVM
                {
                    Name=s.Item.Name,
                    Price=s.Price,
                    Quantity=s.Quantity,
                    Total=s.Price*s.Quantity,
                    Bonus=s.Item_Bonus
                }).ToList()
            }).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(ItemPurchaseVM item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemPurchase purchase = new()
                    {
                        Item_ID = item.Item_ID,
                        Expiration_Date = item.Expiration_Date,
                        Price = item.Price,
                        Receipt_No = item.Receipt_No,
                        Quantity = item.Quantity,
                        Quantity_Per_Item = item.Quantity_Per_Item,
                        Item_Bonus = item.Item_Bonus,
                        Note = item.Note
                    };
                    ItemInfo itemI = new()
                    {
                        Item_Id = item.Item_ID,
                        batch_no = item.Batch_Number,
                        Expiration_Date = item.Expiration_Date,
                        Quantity_in_Pharmacy = item.Quantity,
                        Quantity_in_Storage = 0,
                        Location_in_Pharmacy = "A00",
                        Location_in_Storage = ""
                    };
                    BuyInvoice invoice;
                    try
                    {
                        invoice=await db.buyInvoices.FindAsync(item.Receipt_No);
                        if (invoice.Delegate_Id != item.Delegate_ID)
                        {
                            ViewBag.receipt = item.Receipt_No+1;
                        }
                    }
                    catch
                    {
                        invoice = new()
                        {
                            Date = DateTime.Now,
                            Employee_Id = HttpContext.Session.GetInt32("UID").Value,
                            Delegate_Id = item.Delegate_ID
                        };
                    }
                    invoice.Delegate_Id = item.Delegate_ID;
                    db.items_info.Add(itemI);
                    db.items_purchase.Add(purchase);
                    await db.SaveChangesAsync();
                    TempData["Success"] = "Item Purchased Successfully";
                    return RedirectToAction(nameof(Buy), item.Receipt_No);
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = e.InnerException != null ? e.InnerException : e.Message;
            }
            return View();
        }
        public async Task<IActionResult> Sell(int? receipt)
        {
            if (HttpContext.Session.GetInt32("UID") == null)
            {
                HttpContext.Session.SetString("Redirect", "Business/Buy");
                return RedirectToAction(nameof(UserController.Login), "User");
            }
            if (receipt == 0)
            {
                try
                {
                    receipt = db.items_purchase.Max(p => p.Receipt_No) + 1;
                }
                catch (Exception)
                {
                    receipt = 1;
                }
            }
            ViewBag.Items = new SelectList(await db.items.ToListAsync(), "Item_Id", "Name");
            ViewBag.Receipt = receipt;
            return View();
        }
        public async Task<IActionResult> Sales()
        {
            List<ItemSale> sales = await db.items_sale.ToListAsync();
            return View(sales);
        }
    }
}
