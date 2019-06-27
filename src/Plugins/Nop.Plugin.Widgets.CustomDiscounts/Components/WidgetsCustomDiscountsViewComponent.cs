using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.CustomDiscounts.Components
{
    [ViewComponent(Name = "WidgetsCustomDiscounts")]
    public class WidgetsCustomDiscountsViewComponent : NopViewComponent
    {
        public WidgetsCustomDiscountsViewComponent()
        {

        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            //return Content("<h2>50% Discount only this month</h2>");
            return View("~/Plugins/Widgets.CustomDiscounts/Views/CustomDiscounts.cshtml");
        }
    }
}
