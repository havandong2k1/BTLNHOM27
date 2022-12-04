using System.ComponentModel.DataAnnotations;
namespace BTLNHOM27.Models
{
    public class HopDongNS

    {
        [Key]
        [Required(ErrorMessage ="Mã Nhân Viên không được bỏ trống")]
        [Display(Name ="Mã Nhân Viên")]
        public string? MaNhanVien {get; set;}
        [Required(ErrorMessage ="Phòng Ban không được bỏ trống")]
        [Display(Name ="Phòng Ban")]
        public string? PhongBan {get; set;}
          
        [Display(Name ="Vị Trí")]
        public string? ViTri {get; set;}
        
         [Required(ErrorMessage ="Lương không được bỏ trống")]
        [Display(Name ="Lương")]
         public string? Luong {get; set;}

         [Required(ErrorMessage ="Trạng Thái không được bỏ trống")]
        [Display(Name ="Trạng Thái")]
        
         public string? TrangThai {get; set;}
           
        
       
    }
}