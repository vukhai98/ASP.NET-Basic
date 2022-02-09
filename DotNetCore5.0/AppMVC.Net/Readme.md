## Controller
- Là 1 lớp kế thừa từ lớp Controller: Miscrosoft.Asp.NetCore.Mvc.Controller
- Action trong controller là một phương thức public (không được là static)
- Action trả về  bất kỳ dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua phương thức khởi tạo.
## View
- Là file .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
````
  // {0} -> tên Action
  // {1} -> tên Controller
  // {2} -> tên Area

  options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

  ```
## Truyền dữ liệu sang View
	- Model
	- ViewData
	- ViewBag
	- TempData
##Areas
- Là tên dùng để routing 
- Là cấu trúc thư mục chứa M.V.C
- Thiết lập Area cho controller bằng ```[Area("AreaName")]
- Tạo cấu trúc thư mục
```
dotnet aspnet-codegenerator  area Product
```
## Route
- enpionts.MappControllerRoute
- endpoints.MapAreaControllerRoute
- [AcceptVerbs("POST","GET")]
- [Route"Pattern"]
- [HttpGet] [HttpPost]
## Url Generation
## UrlHelper: Action, ActionLink,RouteUrl,Link
```
Url.Action("PlanetInfo","Planet",new{id= 1},Context.Request.Scheme)

Url.RouteUrl("default", new {controller="First",action= "HelloView",id=1, user= "VuMinhKhai"})
## HtmlTagHelper ```<a> <button> <form>````
Sử dụ thuộc tính :
````
asp-area ="Area"
asp-action = "Action"
asp-controller = "Product"
asp-route......= "123"
asp-route      = "default"