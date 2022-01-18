using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ValidationExample.Models;
using ValidationExample.Validation;

namespace ValidationExample.Pages
{
    public class ContactModel: PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public ContactModel(IWebHostEnvironment evironment)
        {
            _environment = evironment;
        }


        [BindProperty]
        public CustomerInfo customerInfo { set; get; }


        //[Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [CheckFileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Chọn file upload")]
        [BindProperty]
        public IFormFile FileUpload { set; get; }

        [Display(Name = "Chọn upload nhiều file")]
        public IFormFile[] FileUploads { set; get; }
        public void OnGet()
        {

        }
        public string Thongbao { set; get; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Thongbao = " Dữ liêu gửi đến phù hợp";
                if (FileUpload != null)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", FileUpload.FileName);
                    using var fileStream = new FileStream(filePath,FileMode.Create);
                    FileUpload.CopyTo(fileStream);
                }
                foreach (var item in FileUploads)
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads", item.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    item.CopyTo(fileStream);
                }
            }
            else
            {
                Thongbao = " Dữ liêu gửi đến không phù hợp mời bạn nhập lại";
            }
        }
    }
}
