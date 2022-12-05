using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLNHOM27.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<BTLNHOM27.Models.GioiTinh> GioiTinh { get; set; } = default!;

        public DbSet<BTLNHOM27.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BTLNHOM27.Models.NhanSu> NhanSu { get; set; } = default!;

        public DbSet<BTLNHOM27.Models.HopDongNS> HopDongNS { get; set; } = default!;
    }
}
