using System;
using System.Collections.Generic;
using System.Text;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.CustomDiscounts
{
    public class CustomDiscountsPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsCustomDiscounts";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsOverviewTop };
            //return new List<string> { "productdetails_add_info", "productreviews_page_top", "productreviews_page_inside_review", "productreviews_page_bottom", "productdetails_top", "productdetails_overview_top", "productdetails_overview_bottom", "productdetails_inside_overview_buttons_before", "productdetails_inside_overview_buttons_after", "productdetails_essential_top", "productdetails_essential_bottom", "productdetails_bottom", "productdetails_before_pictures", "productdetails_before_collateral", "productdetails_after_pictures", "productdetails_after_breadcrumb", "your_custom_widget_zone" };
        }
    }
}
