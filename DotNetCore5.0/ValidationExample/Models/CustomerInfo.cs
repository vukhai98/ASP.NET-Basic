using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationExample.Binders;
using ValidationExample.Validation;

namespace ValidationExample.Models
{
    public class CustomerInfo
    {
        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(20,MinimumLength=3,ErrorMessage= "{0} phải dài từ {2} ký tự đến {1}")]
        [ModelBinder(BinderType = typeof(UserNameBinding))]
        public string CustomerName { set; get; }
        [DisplayName("Địa chỉ email")]
        [EmailAddress(ErrorMessage ="Địa chỉ email không phù hợp")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Email { set; get; }
        [DisplayName("Năm sinh")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Range(1970,2022,ErrorMessage ="{0} sai,năm sinh phải trong khoảng {1} đến {2}")]
        [SoChan]
        public int? YearOfBirth { set; get; }
    }
}
