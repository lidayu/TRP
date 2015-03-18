using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeViewTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindTreeView2();
        }

        private void BindTreeView2()
        {
            TreeViewItem item1 = new TreeViewItem() { Header = "节点一" };
            TreeViewItem item11 = new TreeViewItem() { Header = "节点1-1" };
            item11.Items.Add("aaaa");
            item11.Items.Add("bbbb");
            item11.Items.Add("cccc");
            item11.Items.Add("dddd");


            item1.Items.Add(item11);
            item1.Items.Add("cccc");
            item1.Items.Add("dddd");

            TreeViewItem item2 = new TreeViewItem() { Header = "节点二" };
            item2.Items.Add("aaaa");
            item2.Items.Add("bbbb");
            item2.Items.Add("cccc");
            item2.Items.Add("dddd");
            
        }


        //选中节点事件
        private void tvProperties_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            PropertyNodeItem item = this.tvProperties.SelectedItem as PropertyNodeItem;
            string nodeText = item.Name;

            //  MessageBox.Show(nodeText);

        }


        //无限接循环子节点添加到根节点下面
        private void ForeachPropertyNode(PropertyNodeItem node, int pid)
        {
            DataTable dtDict = webDict.GetArticles();
            DataView dvDict = dtDict.DefaultView;
            dvDict.RowFilter = " ClassType='3' and ParentId=" + pid;

            if (dvDict.Count > 0)
            {
                foreach (DataRowView view in dvDict)
                {
                    int id = Convert.ToInt32(view["id"].ToString());
                    string name = view["title"].ToString();
                    int parentId = Convert.ToInt32(view["ParentId"].ToString());
                    PropertyNodeItem childNodeItem = new PropertyNodeItem()
                    {
                        DisplayName = name,
                        Name = name,
                        id = id,
                        parentId = parentId,
                        IsExpanded = false
                    };
                    ForeachPropertyNode(childNodeItem, id);
                    node.Children.Add(childNodeItem);
                }
            }

        }

        WebDictClassServices.WebDictClass webDict = new WebDictClass();
        //根节点添加到treeVIew中
        private void loadTree()
        {
            tvProperties.Items.Clear();//加载根节点前先清除Treeview控件项
            List<PropertyNodeItem> itemList = new List<PropertyNodeItem>();
            DataTable dt = webDict.GetArticles();
            DataView dv = dt.DefaultView;
            dv.RowFilter = " ClassType='3' and ParentId=0 ";
            PropertyNodeItem node = new PropertyNodeItem()
            {
                DisplayName = dv[0].Row["title"].ToString(),
                Name = dv[0].Row["title"].ToString(),
                id = Convert.ToInt32(dv[0].Row["id"].ToString()),
                parentId = Convert.ToInt32(dv[0].Row["ParentId"].ToString()),
                IsExpanded = true

            };
            int id = Convert.ToInt32(dv[0]["id"].ToString());
            int pid = Convert.ToInt32(dv[0]["ParentId"].ToString());
            ForeachPropertyNode(node, id);
            itemList.Add(node);

            this.tvProperties.ItemsSource = itemList;
        }

        /// <summary>
        /// 节点类
        /// </summary>
        internal class PropertyNodeItem
        {
            public string Icon { get; set; }
            public string EditIcon { get; set; }
            public string DisplayName { get; set; }
            public string Name { get; set; }
            public int id { get; set; }
            public int parentId { get; set; }
            public bool IsExpanded { get; set; }
            public List<PropertyNodeItem> Children { get; set; }
            public PropertyNodeItem()
            {
                Children = new List<PropertyNodeItem>();
            }
        }
    }
}
