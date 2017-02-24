using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrickManagementSystem.Main.Models.ViewModels
{
    public class Item
    {
        public string ItemID { get; set; }
        public string ReqID { get; set; }
        public string KhataNumber { get; set; }
        public string ItemName { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string Remarks { get; set; }

    }
}