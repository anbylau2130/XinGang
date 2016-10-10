using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XinGang.Model.Model
{
    public class Character
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

         public DateTime UpdateTime { get; set; }

         public string CharacterType { get; set; }

    }
}
