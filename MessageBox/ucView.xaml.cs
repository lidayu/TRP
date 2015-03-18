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
    /// Interaction logic for ucView.xaml
    /// </summary>
    public partial class ucView : UserControl
    {
        public ucView()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            this.textBox1.Text = "lidayu";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = "lidayu after view loaded";
        }

        private void textBox2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.textBox1.Text = "Enter 2";
            
        }

        private void textBox2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.textBox1.Text = "Enter 2";
        }

        private void textBox2_MouseUp(object sender, RoutedEventArgs e)
        {
            


        }

        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = VoucherChanel.ToString();
            string intStr = "0";
            int i = Convert.ToInt32(intStr);
        }

        public int VoucherChanel { get; set; }

       

        
    }
}
