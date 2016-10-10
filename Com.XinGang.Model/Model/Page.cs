using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XinGang.Model.Model
{
    public  class Page
    {
        public int ID { get; set; }

        public string PageName { get; set; }

        public string PageCode { get; set; }

        public string URL { get; set; }

        public virtual List<Menu> Menus { get; set; } 

    }
}
