using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.CustomDiscounts.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.CustomDiscounts.Components
{
    [ViewComponent(Name = "WidgetsCustomDiscounts")]
    public class WidgetsCustomDiscountsViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public WidgetsCustomDiscountsViewComponent(IStoreContext storeContext,
            ISettingService settingService)
        {
            _storeContext = storeContext;
            _settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var customDiscountsSettings = _settingService.LoadSetting<CustomDiscountsSettings>(_storeContext.CurrentStore.Id);

            // Don't display the discount based on date logic
            if (customDiscountsSettings.From >= customDiscountsSettings.To || 
                DateTime.Now > customDiscountsSettings.To || 
                DateTime.Now < customDiscountsSettings.From)
            {
                return Content("");
            }

            var model = new DiscountModel
            {
                DiscountText = customDiscountsSettings.DiscountText
            };

            return View("~/Plugins/Widgets.CustomDiscounts/Views/CustomDiscounts.cshtml", model);
        }
    }
}
