using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parmacy.Shaar.Data;
using Parmacy.Shaar.Models;
using Parmacy.Shaar.Models.ViewModels;

namespace Parmacy.Shaar.Controllers
{
    public class ItemController : Controller
    {
        public ApplicationDbContext db;
        public ItemController(ApplicationDbContext _db)
        {
            db = _db;
        }
        // GET: Item/
        public async Task<IActionResult> Index()
        {
            List<ItemSummaryVM> items = await db.items.Select(i => new ItemSummaryVM
            {
                ID = i.Item_Id,
                Name = i.Name,
                Scientific_Name = i.Scientific_Name,
                Drug_Type = i.Drug_Type
            }).ToListAsync();
            return View(items);
        }

        // GET: Item/Details/{ID}
        public async Task<ActionResult> Details(int ID)
        {
            ItemDetails item = await db.items.Where(i => i.Item_Id == ID).Select(i => new ItemDetails
            {
                Item_Id = i.Item_Id,
                Barcode = i.Barcode,
                Name = i.Name,
                Scientific_Name = i.Scientific_Name,
                description = i.description,
                Manufacture_Location = i.Manufacture_Location,
                Company = i.Company,
                Drug_Type = i.Drug_Type,
                AvailableBatches = db.items_info.Where(ii => ii.Item_Id == ID && ii.Quantity_in_Pharmacy + ii.Quantity_in_Storage > 0).ToList()
            }).FirstOrDefaultAsync();
            return View(item);
        }

        // GET: Item/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.items.Add(item);
                    await db.SaveChangesAsync();
                    TempData["Success"] = "Item Created Successfully";
                    return RedirectToAction(nameof(Index));
                }
                else TempData["Error"] = "Operation failed";
            }
            catch (Exception e) { TempData["Error"] = e.InnerException != null ? e.InnerException : e.Message; }
            return View();
        }

        // GET: ItemController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Item item = db.items.Where(i => i.Item_Id == id).FirstOrDefault();
            return View(item);
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.items.Update(item);
                    await db.SaveChangesAsync();
                    TempData["Success"] = "Item Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                else TempData["Error"] = "Operation failed";
            }
            catch (Exception e) { TempData["error"] = e.InnerException != null ? e.InnerException : e.Message; }
            return View();
        }
        // GET: ItemController/EditInfo/ID=5&ExpirationDate=2021-01-01
        public async Task<IActionResult> EditInfo(int ID, DateTime ExpirationDate)
        {
            ItemInfo item = await db.items_info.Where(i => i.Item_Id == ID && i.Expiration_Date == ExpirationDate).FirstOrDefaultAsync();
            return View(item);
        }
        // POST: ItemController/EditInfo/ID=5&ExpirationDate=2021-01-01
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInfo(ItemInfo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.items_info.Update(item);
                    await db.SaveChangesAsync();
                    TempData["Success"] = "Item Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                else TempData["Error"] = "Operation failed";
            }
            catch (Exception e) { TempData["error"] = e.InnerException != null ? e.InnerException : e.Message; }
            return View();
        }
    }
}
