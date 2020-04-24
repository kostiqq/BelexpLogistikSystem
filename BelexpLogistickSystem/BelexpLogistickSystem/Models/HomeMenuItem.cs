using System;
using System.Collections.Generic;
using System.Text;

namespace BelexpLogistickSystem.Models
{
    public enum MenuItemType
    {
        RideList,
        OrderList
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
