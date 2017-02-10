using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrickManagementSystem.Main.Models
{
    public class ReqFormViewModel
    {
        public tblRequisitionForm ReqForm { get; set; }
        public List<tblItemInfo> ItemList { get; set; }
    }
}