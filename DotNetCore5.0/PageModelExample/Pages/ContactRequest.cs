using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageModelExample
{
    public class ContactRequest : PageModel
    {
        public string UserId { set; get; } = "Id User.....";

        private readonly ILogger<ContactRequest> logger;
        public ContactRequest(ILogger<ContactRequest> _logger)
        {
            _logger = logger;
            _logger.LogInformation("Init contact........");
        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
