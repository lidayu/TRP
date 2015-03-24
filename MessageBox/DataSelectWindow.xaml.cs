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
using System.Windows.Shapes;
using MessageBoxTEST.DataProviderBase;

namespace MessageBoxTEST
{
    /// <summary>
    /// Interaction logic for DataSelectWindow.xaml
    /// </summary>
    public partial class DataSelectWindow : DataSelectWindowBase
    {
        public DataSelectWindow()
        {
            InitializeComponent();
        }       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem selectedItem=this.treeView1.SelectedItem as TreeViewItem;
            string selectedText = selectedItem.Header.ToString();

            string selectCode = "0000";
            DicDataSelectedEventArg paras = new DicDataSelectedEventArg { SelectedText = selectedText, SelectedCode = selectCode };
            OnAfterSelect(paras);
           
            this.Close();
        }


    }
}
