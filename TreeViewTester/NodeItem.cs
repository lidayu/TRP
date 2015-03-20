using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeViewTester
{
    /// <summary>
    /// 节点类
    /// </summary>
    internal class NodeItem
    {
        public string Icon { get; set; }
        public string EditIcon { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public int id { get; set; }
        public int parentId { get; set; }
        public bool IsExpanded { get; set; }
        public List<NodeItem> Children { get; set; }
        public NodeItem()
        {
            Children = new List<NodeItem>();
        }
    }
}
