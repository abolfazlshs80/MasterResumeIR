
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

   public static class CustomHtmlHelper
    {
        // متد سفارشی برای نمایش پیام
        public static IHtmlContent Hello(this IHtmlHelper helper)
        {
            // تولید HTML به صورت داینامیک
            var html = "<div>سلام 111111111111111دنیا!</div>";
            return new HtmlString(html); // بازگرداندن HTML به عنوان خروجی
        }
    }

