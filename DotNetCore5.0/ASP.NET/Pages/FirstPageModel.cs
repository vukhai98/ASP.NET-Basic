using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore
{
    public class FirstPageModel : PageModel
    {
        public string title { set; get; } = "This is page razor of KhaiChelsea";
        public string Welcome(string name)
        {
            return $"Welcome{name} to the website";
        }
        //OnGet,OnGetabc....
        //OnPost(), OnPostAbc()
        //Hander
        public void OnGet()
        {
            Console.Write("Truy van Get");
            ViewData["mydata"] = "Hello My name is Khai";
        }
        //Get,Url?hander= xyz
        public void OnGetXyz()
        {
            Console.Write("Truy van OnGetxyz");
            ViewData["mydata"] = "Hello My name is Khai";
        }
    }
}
