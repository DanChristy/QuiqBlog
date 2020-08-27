using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;

namespace QuiqBlog.TagHelpers {
    [HtmlTargetElement(Attributes = "list, count")]
    public class HidePagerHelper : TagHelper {
        public IEnumerable<object> List { get; set; }
        public int Count { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (List.Count() <= Count)
                output.SuppressOutput();
        }
    }
}