using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.CustomDiscounts
{
    public class CustomDiscountsPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;

        public CustomDiscountsPlugin(ILocalizationService localizationService,
            IWebHelper webHelper,
            ISettingService settingService)
        {
            _localizationService = localizationService;
            _webHelper = webHelper;
            _settingService = settingService;
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsCustomDiscounts";
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsOverviewTop };
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/WidgetsCustomDiscounts/Configure";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new CustomDiscountsSettings
            {
                DiscountText = "Deal of the day!",
                From = DateTime.Now,
                To = DateTime.Now
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.DiscountText", "Discount text");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.DiscountText.Hint", "Enter the discount text to be displayed.");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.Date", "Date settings");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.From", "Discount begin date");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.From.Hint", "Enter the beginning date for the discount");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.To", "Discount end date");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.CustomDiscounts.To.Hint", "Enter the end date for the discount");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<CustomDiscountsSettings>();
            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.DiscountText");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.DiscountText.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.Date");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.From");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.From.Hint");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.To");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.CustomDiscounts.To.Hint");


            base.Uninstall();
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}
