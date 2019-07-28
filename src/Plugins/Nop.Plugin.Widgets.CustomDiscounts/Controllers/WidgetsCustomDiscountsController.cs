using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.CustomDiscounts.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.CustomDiscounts.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class WidgetsCustomDiscountsController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public WidgetsCustomDiscountsController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStoreContext storeContext,
            ISettingService settingService)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _storeContext = storeContext;
            _settingService = settingService;
        }

        public IActionResult Configure()
        {
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var customDiscountsSettings = _settingService.LoadSetting<CustomDiscountsSettings>(storeScope);

            var model = new ConfigurationModel
            {
                DiscountText = customDiscountsSettings.DiscountText,
                From = customDiscountsSettings.From,
                To = customDiscountsSettings.To,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.DiscountText_OverrideForStore = _settingService.SettingExists(customDiscountsSettings, x => x.DiscountText, storeScope);
                model.From_OverrideForStore = _settingService.SettingExists(customDiscountsSettings, x => x.From, storeScope);
                model.To_OverrideForStore = _settingService.SettingExists(customDiscountsSettings, x => x.To, storeScope);
            }

            return View("~/Plugins/Widgets.CustomDiscounts/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var customDiscountsSettings = _settingService.LoadSetting<CustomDiscountsSettings>(storeScope);

            customDiscountsSettings.DiscountText = model.DiscountText;
            customDiscountsSettings.From = model.From;
            customDiscountsSettings.To = model.To;

            _settingService.SaveSettingOverridablePerStore(customDiscountsSettings, x => x.DiscountText, model.DiscountText_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(customDiscountsSettings, x => x.From, model.From_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(customDiscountsSettings, x => x.To, model.To_OverrideForStore, storeScope, false);

            //now clear settings cache
            _settingService.ClearCache();

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}
