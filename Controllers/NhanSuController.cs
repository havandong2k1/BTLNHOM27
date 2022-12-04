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
    public class NhanSuController : Controller
    {
        private readonly MvcMovieContext _context;

        public NhanSuController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: NhanSu
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.NhanSu.Include(n => n.ChucVu).Include(n => n.GioiTinh);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: NhanSu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhanSu == null)
            {
                return NotFound();
            }

            var nhanSu = await _context.NhanSu
                .Include(n => n.ChucVu)
                .Include(n => n.GioiTinh)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nhanSu == null)
            {
                return NotFound();
            }

            return View(nhanSu);
        }

        // GET: NhanSu/Create
        public IActionResult Create()
        {
            ViewData["IDChucVu"] = new SelectList(_context.ChucVu, "IDChucVu", "TenChucVu");
            ViewData["GioiTinhID"] = new SelectList(_context.GioiTinh, "GioiTinhID", "NameGT");
            return View();
        }

        // POST: NhanSu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoVaTen,GioiTinhID,Email,SDT,SoCanCuoc,IDChucVu")] NhanSu nhanSu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanSu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDChucVu"] = new SelectList(_context.ChucVu, "IDChucVu", "TenChucVu", nhanSu.IDChucVu);
            ViewData["GioiTinhID"] = new SelectList(_context.GioiTinh, "GioiTinhID", "NameGT", nhanSu.GioiTinhID);
            return View(nhanSu);
        }

        // GET: NhanSu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhanSu == null)
            {
                return NotFound();
            }

            var nhanSu = await _context.NhanSu.FindAsync(id);
            if (nhanSu == null)
            {
                return NotFound();
            }
            ViewData["IDChucVu"] = new SelectList(_context.ChucVu, "IDChucVu", "IDChucVu", nhanSu.IDChucVu);
            ViewData["GioiTinhID"] = new SelectList(_context.GioiTinh, "GioiTinhID", "GioiTinhID", nhanSu.GioiTinhID);
            return View(nhanSu);
        }

        // POST: NhanSu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,HoVaTen,GioiTinhID,Email,SDT,SoCanCuoc,IDChucVu")] NhanSu nhanSu)
        {
            if (id != nhanSu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanSu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanSuExists(nhanSu.ID))
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
            ViewData["IDChucVu"] = new SelectList(_context.ChucVu, "IDChucVu", "IDChucVu", nhanSu.IDChucVu);
            ViewData["GioiTinhID"] = new SelectList(_context.GioiTinh, "GioiTinhID", "GioiTinhID", nhanSu.GioiTinhID);
            return View(nhanSu);
        }

        // GET: NhanSu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhanSu == null)
            {
                return NotFound();
            }

            var nhanSu = await _context.NhanSu
                .Include(n => n.ChucVu)
                .Include(n => n.GioiTinh)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nhanSu == null)
            {
                return NotFound();
            }

            return View(nhanSu);
        }

        // POST: NhanSu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhanSu == null)
            {
                return Problem("Entity set 'MvcMovieContext.NhanSu'  is null.");
            }
            var nhanSu = await _context.NhanSu.FindAsync(id);
            if (nhanSu != null)
            {
                _context.NhanSu.Remove(nhanSu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanSuExists(string id)
        {
          return (_context.NhanSu?.Any(e => e.ID == id)).GetValueOrDefault();
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
                            var ns = new NhanSu();
                            //set values for attribiutes
                            ns.ID = dt.Rows[i][0].ToString();
                            ns.HoVaTen = dt.Rows[i][1].ToString();
                            ns.GioiTinhID = dt.Rows[i][2].ToString();
                            ns.Email = dt.Rows[i][3].ToString();
                            ns.SDT = dt.Rows[i][4].ToString();
                            ns.SoCanCuoc = dt.Rows[i][5].ToString();
                            ns.IDChucVu = dt.Rows[i][6].ToString();
                            //add oject to context
                            _context.NhanSu.Add(ns);
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
        



    

