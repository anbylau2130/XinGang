using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.XinGang.Model.Model
{
    public class ExtTreeNode
    {
        //定义jsondata类，存放节点数据
        public string id;
        public string text;
        public bool leaf;
        public  string  type;
        public List<ExtTreeNode> children = new List<ExtTreeNode>();//存放子节点
    }
}