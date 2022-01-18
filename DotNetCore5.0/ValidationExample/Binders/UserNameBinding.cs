using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationExample.Binders
{

    /*
        - Chuyển tên thành chữ in hoa
        - Tên không được chứ xxx
        - Cắt khoảng trắng ở đầu và cuối 
     */
    public class UserNameBinding : IModelBinder
    {
        public  Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext==null)
            throw new NotImplementedException("bindingContext");
            string modelName = bindingContext.ModelName;

            //Read value send
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                  
                  return  Task.CompletedTask;
            }
            string value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }
            // Binding

            string s = value.ToUpper();

            if (s.Contains("XXX"))
            {
                bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
                bindingContext.ModelState.TryAddModelError(modelName, "Lỗi vì tên chứ xxx");
            }
            s = s.Trim();

            bindingContext.ModelState.SetModelValue(modelName, s, s);

            bindingContext.Result = ModelBindingResult.Success(s);
            return Task.CompletedTask;
        }
    }
}
