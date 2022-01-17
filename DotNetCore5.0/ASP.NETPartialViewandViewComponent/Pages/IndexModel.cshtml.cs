using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETPartialViewandViewComponent.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public IActionResult OnPost()
        {
            var username = this.Request.Form["username"];
            var message = new MessagePage.Message();
            message.title = "Message";
            message.htmlcontent = $"Thank {username} send information for us";
            message.secondwait = 5;
            message.urlredirect = Url.Page("Privacy");

            return ViewComponent("MessagePage", message);
        }

        //public IActionResult OnGet()
        //{
        //    //PageModel: Partial, ViewComponent
        //    //Controller:PartialView, ViewComponent
        //    //return Partial("_Message");
        //    return ViewComponent("ProductBox",true);
        //}
    }
}
