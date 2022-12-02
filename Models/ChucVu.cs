using System.ComponentModel.DataAnnotations;
namespace BTLNHOM27.Models
{
    public class ChucVu

    {
        [Key]
        public string? IDChucVu {get; set;}
        
        public string? TenChucVu {get; set;}
       
    }
}