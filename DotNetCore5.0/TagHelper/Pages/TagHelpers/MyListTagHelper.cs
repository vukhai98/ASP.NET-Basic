using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace TAGHELPEREXAMPLE
{
    // thẻ sẽ là mylist
    [HtmlTargetElement("mylist")]
    public class MyListTagHelper : ITagHelper
    {
        // Thuộc tính sẽ là list-title
        public string ListTitle { get; set; }

        // Thuộc tính sẽ là list-items
        public List<string> ListItems { set; get; }

        public int Order => throw new NotImplementedException();

        public void Init(TagHelperContext context)
        {
            throw new NotImplementedException();
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";    // ul sẽ thay cho myul
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", "list-group");
            output.PreElement.AppendHtml($"<h2>{ListTitle}</h2>");


            StringBuilder content = new StringBuilder();
            foreach (var item in ListItems)
            {
                content.Append($@"<li class=""list-group-item"">{item}</li>");
            }
            output.Content.SetHtmlContent(content.ToString());
        }

        public Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            throw new NotImplementedException();
        }
    }

}

