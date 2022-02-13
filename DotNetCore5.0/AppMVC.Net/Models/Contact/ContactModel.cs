using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Net.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Phải nhập {0}")]
        [Display(Name ="Họ Tên")]
        public string FullName { set; get; }


        [Required(ErrorMessage = "Phải nhập {0}")]
        [EmailAddress(ErrorMessage ="Phải là địa chỉ email")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ Email")]
        public string Email { set; get; }

        public DateTime DateSent { set; get; }

        
        [Display(Name = "Nội dung")]
        public string Message { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Phone(ErrorMessage ="Phải là số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string Phone { set; get; }
    }
}
