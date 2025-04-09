


namespace MsaterResumeIR.Tools.TagHelper.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    public class HelloTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // تنظیم خروجی HTML
            output.TagName = "div"; // تگ <div> را به عنوان خروجی تنظیم می‌کنیم
            output.Content.SetContent("سلام دنیا!"); // محتوای داخل تگ
        }
    }
}
