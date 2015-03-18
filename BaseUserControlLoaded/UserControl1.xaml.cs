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
using BaseUserControlLoaded.Base;

namespace BaseUserControlLoaded
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : BaseView
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void BaseView_Loaded(object sender, RoutedEventArgs e)
        {
            EqukContext.IDName = "lidayu";
            DateTime onn=DateTime.Now;
            string onnStr = onn.ToShortDateString();
            string inputStr="2015-10-01";
            string[] dateSet=inputStr.Split(new Char[]{'-'});
            int yearVal=Convert.ToInt32(dateSet[0]);
            int monthVal=Convert.ToInt32(dateSet[1]);
            int dayVal=Convert.ToInt32(dateSet[2]);
            DateTime compareDate=new DateTime();
            if (onn > compareDate)
            {
                this.textBox1.Text = onn.ToShortDateString();
            }
            else
            {
                this.textBox1.Text = compareDate.ToShortDateString();
            }
        }
    }
}
