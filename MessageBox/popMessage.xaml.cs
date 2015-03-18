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

namespace MessageBoxTEST
{
    /// <summary>
    /// Interaction logic for popMessage.xaml
    /// </summary>
    public partial class popMessage : Window
    {
        private string temp = "";
        public popMessage()
        {
            InitializeComponent();
        }
        public popMessage(ref string value)
        {
 
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.textBox1.Text = "ahahahahahahah";
        }

        //private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    TreeView treeVIew = new TreeView();
        //    TreeViewItem rootItem = new TreeViewItem();
        //    rootItem.Header = "CN";
            
        //    for (int i = 0; i < 10; i++)
        //    {
        //        TreeViewItem aItem = new TreeViewItem();
        //        aItem.Header = i;

        //        rootItem.Items.Add(aItem);
        //    }
        //    ContentControl cc = new ContentControl();
        //    cc.Content = treeVIew;

        //    this.AddChild(cc);
            
        //}
    }
}
