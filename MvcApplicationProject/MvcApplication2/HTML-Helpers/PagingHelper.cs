using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
namespace MvcApplication2.HTML_Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PagingNavigator(this HtmlHelper helper, int pageNum, int countOfItems, int pageSize)
        {
            StringBuilder strBuild = new StringBuilder();
            int pagesCount = (int)Math.Ceiling((double)(countOfItems / pageSize));
            if (pageNum > 0)
                strBuild.Append(helper.ActionLink("<= PrevPage ", "Index", new { pageNum = pageNum - 1 }));
            else 
                strBuild.Append(HttpUtility.HtmlEncode("<= PrevPage "));
            if (pageNum < pagesCount)
                strBuild.Append(helper.ActionLink(" NextPage =>", "Index", new { pageNum = pageNum + 1 }));
            else
                strBuild.Append(HttpUtility.HtmlEncode(" NextPage =>"));
            return MvcHtmlString.Create(strBuild.ToString());
        }
    }
}