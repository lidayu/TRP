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

namespace DeSerialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        }
    }
}
