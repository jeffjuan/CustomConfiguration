using CustomConfig.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CustomConfig.MyHtmlHelper
{
    public static class CustomHelper
    {
        public static MvcHtmlString GetData(string name)
        {
            var dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", name);
            StringBuilder option = new StringBuilder();
            MyDataConfig mySection = (ConfigurationManager.GetSection("MyConfigSection") as MyDataConfig);
            foreach (MyConfigElement item in mySection.CountyCollection)
            {
                option = option.Append("<option value='" + item.CountyValue + "'>" + item.CountyKey + "</option>");
            }
            dropdown.InnerHtml = option.ToString();
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
    }
}