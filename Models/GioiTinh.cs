using System.ComponentModel.DataAnnotations;
namespace BTLNHOM27.Models
{
    public class GioiTinh

    {
        [Key]
        public string? GioiTinhID {get; set;}
        
        public string? NameGT {get; set;}
       
    }
}