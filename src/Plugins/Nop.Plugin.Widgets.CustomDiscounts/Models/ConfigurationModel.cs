using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.CustomDiscounts.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.CustomDiscounts.DiscountText")]
        [UIHint("DiscountText")]
        public string DiscountText { get; set; }
        public bool DiscountText_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.CustomDiscounts.From")]
        [UIHint("From")]
        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }
        public bool From_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.CustomDiscounts.To")]
        [UIHint("To")]
        [DataType(DataType.DateTime)]
        public DateTime To { get; set; }
        public bool To_OverrideForStore { get; set; }
    }
}
