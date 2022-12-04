using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLNHOM27.Models
{
    public class NhanSu

    {
        [Key]
        [Required(ErrorMessage ="ID không được bỏ trống")]
        public string? ID {get; set;}
        
        [Required(ErrorMessage ="Họ Và Tên không được bỏ trống")]
        [Display(Name ="Họ Và Tên")]
        public string? HoVaTen {get; set;}
         public string? GioiTinhID {get; set;}
        [ForeignKey("GioiTinhID")]
        [Display(Name ="Giới Tính")]
        public GioiTinh? GioiTinh {get; set;}
        [Required(ErrorMessage =" Email Không được bỏ trống")]
        [Display(Name ="Email")]
        public string? Email {get; set;}
        [Required(ErrorMessage =" SĐt Không được bỏ trống")]
        [Display(Name ="Số Điện Thoại")]
        public string? SDT {get; set;}
        [Required(ErrorMessage =" Số Cắn Cước Không được bỏ trống")]
        [Display(Name ="Số Căn Cước")]
        public string? SoCanCuoc {get; set;}
        
        public string? IDChucVu  {get; set;}
        [ForeignKey("IDChucVu")]
        [Display(Name ="Chức Vụ")]
        
        public ChucVu? ChucVu {get; set;}
    }
}
