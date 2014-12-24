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
using System.Xml.Serialization;
using System.Xml;
using System.IO;


namespace DeSerialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<transaction> tranInfoList;
        public MainWindow()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            string InXml = doc.OuterXml;
            this.DataContext = new MainViewModel(InXml);


            #region  动态绑定
            Binding dynamicBinding = new Binding();
            dynamicBinding.Source = this.DataContext;
            
            dynamicBinding.Path = new PropertyPath("ModelContext");

            this.equkTextBox1.SetBinding(EqukTextBox.TextProperty, dynamicBinding);
            //Text="{Binding ModelContext['EQUK.UserInfo.name']}"
            //this.equkTextBox1.Text = "{Binding ModelContext[\"EQUK.UserInfo.name\"]}";
            #endregion
        }

        /// <summary>
        /// 调试获取断点，以查看MainViewModel实例数据是否经过了RaieProperty操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
           // Class2Xml();
            XmlToClass();


        }
        
        private void XmlToClass()
        {
            tranInfoList = new List<transaction>();
            try
            {
                //这种读取方式，这个xml需要保存时Unicode格式，不是utf-8
                //utf-8编码为utf-8,如果是utf-16，编码为unicode
                XmlReader xmlReader = XmlReader.Create("conf\\transaction.xml");


                XmlSerializer xmlSearializer = new XmlSerializer(typeof(Trans));
                Trans info = (Trans)xmlSearializer.Deserialize(xmlReader);
            }
            catch
            {

            }


           
            
        }

        /// <summary>
        /// 把类序列化为xml
        /// </summary>
        private void Class2Xml()
        {
            StringWriter sw = new StringWriter();
            //创建XML命名空间
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(Trans));
            Trans trans = new Trans();
            transaction firstTran = new transaction();
            firstTran.ID = "1";
            firstTran.Name = "firstran";
            firstTran.Image = "fljsadkffdklsjslkfjdskl";
            transaction secondTran = new transaction();
            secondTran.ID = "2";
            secondTran.Name = "secondTran";
            secondTran.Image = "kfjkjkkkkkkkkkkkkkkkk";
            trans.TranList.Add(firstTran); trans.TranList.Add(secondTran);
            serializer.Serialize(sw, trans, ns);
            sw.Close();
        }


    }
}
