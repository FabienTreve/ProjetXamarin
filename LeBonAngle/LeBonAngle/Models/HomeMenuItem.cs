using System;
using System.Collections.Generic;
using System.Text;

namespace LeBonAngle.Models
{
    public enum MenuItemType
    {
        AnnounceList,
        AnnounceDeposit,
        Messages,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public bool IsEnable { get; set; }

        public string TargetPage { get; set; }
    }
}
