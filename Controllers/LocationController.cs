using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parmacy.Shaar.Data;
using Parmacy.Shaar.Models;
using Parmacy.Shaar.Models.ViewModels;

namespace Parmacy.Shaar.Controllers
{
    public class LocationController : Controller
    {
        public ApplicationDbContext db;
        public LocationController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Items()
        {
            List<ItemLocationVM> items = await db.items_info.Select(x => new ItemLocationVM
            {
                ItemID = x.Item_Id,
                Item_Name = x.Item.Name,
                Quantity =
                (x.Quantity_in_Pharmacy != 0 ? "P-" + x.Quantity_in_Pharmacy : "") +
                (x.Quantity_in_Pharmacy != 0 && x.Quantity_in_Storage != 0 ? " / " : "") +
                (x.Quantity_in_Storage != 0 ? "S-" + x.Quantity_in_Storage : ""),
                Location =
                (x.Quantity_in_Pharmacy != 0 ? "P-" + x.Location_in_Pharmacy : "") +
                (x.Quantity_in_Pharmacy != 0 && x.Quantity_in_Storage != 0 ? " / " : "") +
                (x.Quantity_in_Storage != 0 ? "S-" + x.Location_in_Storage : ""),
                Expiration_Date = x.Expiration_Date.ToShortDateString(),
            }).ToListAsync();
            return View(items);
        }
        public async Task<IActionResult> Transfer(int? ID,DateTime ExpirationDate)
        {
            if (ID == null)
            {
                return NotFound();
            }
            ItemTransferVM item = db.items_info.Where(i => i.Item_Id == ID && i.Expiration_Date == ExpirationDate).Select(x => new ItemTransferVM
            {
                ID = x.Item_Id,
                ExpirationDate = new DateOnly(x.Expiration_Date.Year,x.Expiration_Date.Month,x.Expiration_Date.Day),
                QuantityInPharmacy = x.Quantity_in_Pharmacy,
                QuantityInStorage = x.Quantity_in_Storage,
                LocationInPharmacy = x.Location_in_Pharmacy,
                LocationInStorage = x.Location_in_Storage,
            }).FirstOrDefault();
            ViewBag.ItemName= db.items_info.Where(i => i.Item_Id == ID).Select(x => x.Item.Name).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(ItemTransferVM item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemInfo item_info = db.items_info.Where(i => i.Item_Id == item.ID && i.Expiration_Date == item.ExpirationDate.ToDateTime(TimeOnly.MinValue)).FirstOrDefault();
                    item_info.Quantity_in_Pharmacy = item.QuantityInPharmacy;
                    item_info.Quantity_in_Storage = item.QuantityInStorage;
                    item_info.Location_in_Pharmacy = item.LocationInPharmacy;
                    item_info.Location_in_Storage = item.LocationInStorage;
                    db.Update(item_info);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Items));
                }
                else TempData["Error"] = "Operation failed";
            }
            catch(Exception e)
            {
                TempData["Error"] = e.InnerException != null ? e.InnerException : e.Message;
            }
            return View(item);
        }
    }
}
