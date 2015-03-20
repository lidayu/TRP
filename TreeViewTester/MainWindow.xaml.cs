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
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections;

namespace TreeViewTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch appStopWatch;
        public MainWindow()
        {
            InitializeComponent();
            appStopWatch = new Stopwatch();

            //List<NodeItem> treeViewList = new List<NodeItem>();
            //NodeItem rootNode = new NodeItem { parentId = -1, DisplayName = "证件类型", id = 1};
            //List<NodeItem> treeViewList1 = new List<NodeItem>();
            //NodeItem atNode1 = new NodeItem { parentId = 1, DisplayName = "居民身份证1", id = 110001 }; treeViewList1.Add(atNode1);
            //List<NodeItem> treeViewList2 = new List<NodeItem>();
            //NodeItem atNode2 = new NodeItem { parentId = 1, DisplayName = "居民身份证2", id = 110002 }; treeViewList1.Add(atNode2);
            //List<NodeItem> treeViewList3 = new List<NodeItem>();
            //NodeItem atNode3 = new NodeItem { parentId = 1, DisplayName = "居民身份证3", id = 110003 }; treeViewList1.Add(atNode3);
            //List<NodeItem> treeViewList4 = new List<NodeItem>();
            //NodeItem atNode4 = new NodeItem { parentId = 1, DisplayName = "居民身份证4", id = 110004 }; treeViewList1.Add(atNode4);
            //List<NodeItem> treeViewList5 = new List<NodeItem>();
            //NodeItem atNode5 = new NodeItem { parentId = 1, DisplayName = "居民身份证5", id = 110005 }; treeViewList1.Add(atNode5);
            //List<NodeItem> treeViewList6 = new List<NodeItem>();
            //NodeItem atNode6 = new NodeItem { parentId = 1, DisplayName = "居民身份证6", id = 110006 }; treeViewList1.Add(atNode6);
            //rootNode.Children = treeViewList1;
            //treeViewList.Add(rootNode);

            //tvProperties.ItemsSource = treeViewList;
            //BindTreeView2();
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

            NodeItem item = this.tvProperties.SelectedItem as NodeItem;
            string nodeText = "Name:"+item.DisplayName+"|ID:"+item.id.ToString();
            label1.Content = nodeText;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            appStopWatch.Start();
            try
            {
                //这种读取方式，这个xml需要保存时Unicode格式，不是utf-8
                //utf-8编码为utf-8,如果是utf-16，编码为unicode
                XmlDocument xmlDoc = new XmlDocument();
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string dataFile=path+"EqukCommonData1.xml";
                xmlDoc.Load(dataFile);
                XmlNode rootNode=xmlDoc.SelectSingleNode("//peoples");

                XmlReader xmlReader = XmlReader.Create("EqukCommonData1.xml");
                XmlSerializer xmlSearializer = new XmlSerializer(typeof(EqukCommonData));
                EqukCommonData equkCommonData = (EqukCommonData)xmlSearializer.Deserialize(xmlReader);

                XmlReader xmlPeoplesReader = XmlReader.Create("PeoplesData.xml");
                XmlSerializer xmlPeoplesSerializer = new XmlSerializer(typeof(peoples));
                peoples peopleSet = (peoples)xmlPeoplesSerializer.Deserialize(xmlReader);

                //如果是民族
                //tvProperties.ItemsSource = getPeoples(equkCommonData);

                //加载发证机关
                tvProperties.ItemsSource = getIDPublishers(equkCommonData);
                appStopWatch.Stop();
                label2.Content = "加载耗时：" + appStopWatch.ElapsedMilliseconds.ToString() + "   ms";

            }
            catch
            {

            }
        }


        private List<NodeItem> getPeoples(peoples equkCommonData)
        {
            List<NodeItem> treeViewItemSource = new List<NodeItem>();
            NodeItem peopleRootNode = new NodeItem { parentId = -1, DisplayName = "证件类型", id = 0 };
            treeViewItemSource.Add(peopleRootNode);


            List<people> peopleTypes = equkCommonData.PeopleList;
            List<NodeItem> peopleDicData = new List<NodeItem>();
            int nodeCount = peopleRootNode.parentId + 1;
            foreach (people aPeopleType in peopleTypes)
            {
                NodeItem peopleNode = new NodeItem
                {

                    //parentId = peopleRootNode.id,
                    DisplayName = aPeopleType.name,
                    id = Int32.Parse(aPeopleType.code),
                };
                peopleDicData.Add(peopleNode);
            }
            peopleRootNode.Children = peopleDicData;

            return treeViewItemSource; 
 
        }
        private List<NodeItem> getPeoples(EqukCommonData equkCommonData)
        {
            return getPeoples(equkCommonData.PeoplesList);
        }

        private List<NodeItem> getIDPublishers(IDPublishers equkCommonData)
        {
            //记录节点与id对
            Hashtable provAndChildren=new Hashtable();
            Hashtable cityAndChildren = new Hashtable();

            List<NodeItem> treeViewItemSource = new List<NodeItem>();
            NodeItem idPubsRootNode = new NodeItem { parentId = -1, DisplayName = "发证机关", id = 0 };            
            treeViewItemSource.Add(idPubsRootNode);
            //创建用于存储省的List
            List<NodeItem> rootChildrenList = new List<NodeItem>();
            idPubsRootNode.Children = rootChildrenList;

            List<IDPublisher> idPubs = equkCommonData.IdPublisherList;
            foreach (IDPublisher aIdPub in idPubs)
            {
                //增加省
                NodeItem idPubProvNode = new NodeItem
                {
                    DisplayName = aIdPub.pro,
                };

                if (!provAndChildren.ContainsKey(aIdPub.pro))
                {
                    List<NodeItem> idPubsDicData = new List<NodeItem>();
                    provAndChildren.Add(aIdPub.pro, idPubsDicData);

                    
                    //将省加到root节点的children
                    rootChildrenList.Add(idPubProvNode);
                }

                //*************************************************************************
                //增加市
                NodeItem idPubCityNode = new NodeItem
                {
                    DisplayName = aIdPub.city,
                };
                List<NodeItem> provChildrenList = provAndChildren[aIdPub.pro] as List<NodeItem>;
                if (!cityAndChildren.ContainsKey(aIdPub.city))
                {
                    List<NodeItem> idPubsDicData = new List<NodeItem>();
                    cityAndChildren.Add(aIdPub.city, idPubsDicData);

                    //将市节点加到省的children                    
                    if (provChildrenList == null)
                        continue;
                    provChildrenList.Add(idPubCityNode);
                }  

                idPubProvNode.Children = provChildrenList;
                //*************************************************************************
                //增加县、区  
                NodeItem idPubAreaNode = new NodeItem
                {
                    DisplayName = aIdPub.area,
                    id =Int32.Parse(aIdPub.id),
                };

                //将区县节点加到市的children
                List<NodeItem> cityChildrenList = cityAndChildren[aIdPub.city] as List<NodeItem>;
                if (cityChildrenList == null)
                    continue;
                cityChildrenList.Add(idPubAreaNode);

                idPubCityNode.Children = cityChildrenList;
            }
            return treeViewItemSource; 
 
        }
        private List<NodeItem> getIDPublishers(EqukCommonData equkCommonData)
        {
            return getIDPublishers(equkCommonData.IdPublishersList);        
        }





        #region  old back
        ////无限接循环子节点添加到根节点下面
        //private void ForeachPropertyNode(PropertyNodeItem node, int pid)
        //{
        //    DataTable dtDict = webDict.GetArticles();
        //    DataView dvDict = dtDict.DefaultView;
        //    dvDict.RowFilter = " ClassType='3' and ParentId=" + pid;

        //    if (dvDict.Count > 0)
        //    {
        //        foreach (DataRowView view in dvDict)
        //        {
        //            int id = Convert.ToInt32(view["id"].ToString());
        //            string name = view["title"].ToString();
        //            int parentId = Convert.ToInt32(view["ParentId"].ToString());
        //            PropertyNodeItem childNodeItem = new PropertyNodeItem()
        //            {
        //                DisplayName = name,
        //                Name = name,
        //                id = id,
        //                parentId = parentId,
        //                IsExpanded = false
        //            };
        //            ForeachPropertyNode(childNodeItem, id);
        //            node.Children.Add(childNodeItem);
        //        }
        //    }

        //}

        //WebDictClassServices.WebDictClass webDict = new WebDictClass();
        ////根节点添加到treeVIew中
        //private void loadTree()
        //{
        //    tvProperties.Items.Clear();//加载根节点前先清除Treeview控件项
        //    List<PropertyNodeItem> itemList = new List<PropertyNodeItem>();
        //    DataTable dt = webDict.GetArticles();
        //    DataView dv = dt.DefaultView;
        //    dv.RowFilter = " ClassType='3' and ParentId=0 ";
        //    PropertyNodeItem node = new PropertyNodeItem()
        //    {
        //        DisplayName = dv[0].Row["title"].ToString(),
        //        Name = dv[0].Row["title"].ToString(),
        //        id = Convert.ToInt32(dv[0].Row["id"].ToString()),
        //        parentId = Convert.ToInt32(dv[0].Row["ParentId"].ToString()),
        //        IsExpanded = true

        //    };
        //    int id = Convert.ToInt32(dv[0]["id"].ToString());
        //    int pid = Convert.ToInt32(dv[0]["ParentId"].ToString());
        //    ForeachPropertyNode(node, id);
        //    itemList.Add(node);

        //    this.tvProperties.ItemsSource = itemList;
        //}
        #endregion

    }
}
