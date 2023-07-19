using System.ComponentModel.DataAnnotations;

namespace My_web_API.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]

        public string TenLoai { get; set; }
    }
}
