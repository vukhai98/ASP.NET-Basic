using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PageModelExample
{
    public class ContactRequest : PageModel
    {
        [BindProperty ]
        [DisplayName("YourID")]
        [Range(10,100,ErrorMessage ="Nhập sai")]
        public int UserId { set; get; }
        [BindProperty]
        [DisplayName("YourEmail")]
        [EmailAddress(ErrorMessage ="Email  sai định dạng")]
        public string Email { set; get; }
        [BindProperty]
        [DisplayName("UserName")]
        public string UserName { set; get; }

        private readonly ILogger<ContactRequest> _logger;
        public ContactRequest(ILogger<ContactRequest> logger)
        {
            _logger = logger;
           _logger.LogInformation("Init contact........");
        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
        public void OnPost()
        {
            Console.WriteLine(this.Email);
        }
    }
}
