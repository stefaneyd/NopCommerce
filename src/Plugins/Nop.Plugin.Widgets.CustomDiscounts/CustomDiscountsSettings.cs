using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.CustomDiscounts
{
    public class CustomDiscountsSettings : ISettings
    {
        public string DiscountText { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
