using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XinGang.Model.Model
{
    [Serializable]
    public class Menu
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 显示文本
        /// </summary>
        [Required]
        public string Text { get; set; }

        public int PageID { get; set; }
        
        public int ContentTypeID { get; set; }

        public virtual ContentType ContentType { get; set; }

        public virtual Page Page { get; set; }

        public virtual List<Content> Contents { get; set; }

    }
}
