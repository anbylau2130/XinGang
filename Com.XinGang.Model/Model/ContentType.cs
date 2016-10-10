using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XinGang.Model.Model
{
    public  class ContentType 
    {
       public int ID { get; set; }
       public string TypeName { get; set; }
       public string TypeCode { get; set; } 
       public string Controller { get; set; }
       public string View { get; set; }

        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
