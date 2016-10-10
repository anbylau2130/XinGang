using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XinGang.Model.Model
{
   public  class Content
    {
       public int ID { get; set; }

       public string Title { get; set; }

       public string Text { get; set; }  

       public DateTime CreateTime { get; set; }

       public DateTime UpdateTime { get; set; }

       public int MenuID { get; set; }

       public virtual Menu Menu { get; set; }
    }
}
