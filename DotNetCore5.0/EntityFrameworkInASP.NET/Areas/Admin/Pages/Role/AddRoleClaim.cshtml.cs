using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EntityFrameworkInASP.NET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EntityFrameworkInASP.NET.Areas.Admin.Pages.Role
{
    [Authorize(Roles = "Admin")]
    public class AddRoleClaimModel : RolePageModel
    {
        public AddRoleClaimModel(RoleManager<IdentityRole> roleManager, MyBlogContext myBlogContext) : base(roleManager, myBlogContext)
        {
        }



        public class InputModel
        {
            [Display(Name = " Kiểu (tên) claim")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự. ")]
            public string ClaimType { set; get; }


            [Display(Name = " Giá trị")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự. ")]
            public string ClaimValue { set; get; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IdentityRole role { set; get; }
        public async Task<IActionResult> OnGet(string roleId)
        {
            role = await _roleManager.FindByIdAsync(roleId);
            if (role==null)
            {
                return NotFound("Không tìm thấy role");
                
            }
            return Page();
        }
        public async Task<IActionResult>OnPostAsync( string roleId)
        {
            role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound("Không tìm thấy role");

            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if ((await _roleManager.GetClaimsAsync(role)).Any(c => c.Type == Input.ClaimType && c.Value == Input.ClaimValue))
            {
                ModelState.AddModelError(string.Empty, "Claim này đã có trong role");
                return Page();
            }
            var newClaim = new Claim(Input.ClaimType, Input.ClaimValue);

            var result = await _roleManager.AddClaimAsync(role, newClaim);
            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(e=>{
                    ModelState.AddModelError(string.Empty, e.Description);
                });
                return Page();
            }

            StatusMessage = " Vừa thêm đặc tính (claim) mới";

            return RedirectToPage("./Edit", new { roleId = role.Id });



        }
    }
}
