using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNHOM27.Models;
using BTLNHOM27.Models.Process;
using MvcMovie.Data;

namespace BTLNHOM27.Controllers
{
    public class HopDongNSController : Controller
    {
        private readonly MvcMovieContext _context;

        public HopDongNSController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: HopDongNS
        public async Task<IActionResult> Index()
        {
              return _context.HopDongNS != null ? 
                          View(await _context.HopDongNS.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.HopDongNS'  is null.");
        }

        // GET: HopDongNS/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HopDongNS == null)
            {
                return NotFound();
            }

            var hopDongNS = await _context.HopDongNS
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (hopDongNS == null)
            {
                return NotFound();
            }

            return View(hopDongNS);
        }

        // GET: HopDongNS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HopDongNS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,PhongBan,ViTri,Luong,TrangThai")] HopDongNS hopDongNS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDongNS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopDongNS);
        }

        // GET: HopDongNS/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HopDongNS == null)
            {
                return NotFound();
            }

            var hopDongNS = await _context.HopDongNS.FindAsync(id);
            if (hopDongNS == null)
            {
                return NotFound();
            }
            return View(hopDongNS);
        }

        // POST: HopDongNS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhanVien,PhongBan,ViTri,Luong,TrangThai")] HopDongNS hopDongNS)
        {
            if (id != hopDongNS.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDongNS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongNSExists(hopDongNS.MaNhanVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hopDongNS);
        }

        // GET: HopDongNS/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HopDongNS == null)
            {
                return NotFound();
            }

            var hopDongNS = await _context.HopDongNS
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (hopDongNS == null)
            {
                return NotFound();
            }

            return View(hopDongNS);
        }

        // POST: HopDongNS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HopDongNS == null)
            {
                return Problem("Entity set 'MvcMovieContext.HopDongNS'  is null.");
            }
            var hopDongNS = await _context.HopDongNS.FindAsync(id);
            if (hopDongNS != null)
            {
                _context.HopDongNS.Remove(hopDongNS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongNSExists(string id)
        {
          return (_context.HopDongNS?.Any(e => e.MaNhanVien == id)).GetValueOrDefault();
        }
         private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data form dt
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var hd = new HopDongNS();
                            //set values for attribiutes
                            hd.MaNhanVien = dt.Rows[i][0].ToString();
                            hd.PhongBan = dt.Rows[i][1].ToString();
                            hd.ViTri = dt.Rows[i][2].ToString();
                            hd.Luong = dt.Rows[i][3].ToString();
                            hd.TrangThai = dt.Rows[i][4].ToString();
                            //add oject to context
                            _context.HopDongNS.Add(hd);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        
    }
    }
}
