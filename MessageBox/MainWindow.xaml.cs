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
using System.Collections;
using System.Xml;

namespace MessageBoxTEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        private Hashtable equkData=new Hashtable();
        public MainWindow()
        {
            InitializeComponent();
            comboBox1.Text = "4"; 
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("qing fang ru", "Ready to print", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                MessageBox.Show("printing....");
                MessageBoxResult mbr2 = MessageBox.Show("是否重打，点否进入下一界面", "Ready to print", MessageBoxButton.YesNo);

            }
            else
                MessageBox.Show("cancelled");
            
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != "doylee")
            {
                MessageBox.Show("please input 'doylee'");
                //bool trueOrfalse=this.textBox1.Focus();
                //if (trueOrfalse)
                //{

                //    this.textBox1.Background = Brushes.Red;
                //}
                //textBox1.Focus();
                this.textBox1.Foreground = Brushes.Red;
                this.textBox1.Background = Brushes.YellowGreen;                
            }
            else
            {
                this.textBox1.Background = Brushes.White;
                this.textBox1.Foreground = Brushes.Black;
            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            GetViewData(this);
            
        }

        private void GetViewData(Visual myVisual)
        {            
            int controlCount = VisualTreeHelper.GetChildrenCount(myVisual);

            for (int i = 0; i <controlCount; i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                if (childVisual != null)
                {                    
                    if (childVisual is TextBox)                    
                    { 
                        TextBox childTextBox=childVisual as TextBox;
                        equkData.Add(childTextBox.Name, childTextBox.Text);
                        childTextBox.IsEnabled = false;
                    }
                    else if (childVisual is RadioButton)
                    {
                        RadioButton childRadioButton = childVisual as RadioButton;
                        if (childRadioButton.IsChecked.Value)
                            equkData.Add(childRadioButton.Content, "true");
                        childRadioButton.IsEnabled = false;
                    }
                    else if (childVisual is CheckBox)
                    {
                        CheckBox childCB = childVisual as CheckBox;
                        if (childCB.IsChecked.Value)
                            equkData.Add(childCB.Content, "true");
                        childCB.IsEnabled = false;
                    }
                    else if (childVisual is Label)
                    {
                        Label childLb = childVisual as Label;
                        string childLbTxt = childLb.Content.ToString();
                    }
                    else if (childVisual is ComboBox)
                    {
                        ComboBox childComboBox = childVisual as ComboBox;
                        childComboBox.IsEnabled = false;
                    }
                    else
                        GetViewData(childVisual); 
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem=comboBox1.SelectedItem as ComboBoxItem;
            
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");
            XmlNode aNode = doc.SelectSingleNode("//BoEing");
            XmlNodeList nodeList = aNode.SelectNodes("module");

        }

        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            string dateSelected = DateTime.Now.ToShortDateString();
            dateSelected.Replace("-", "/");
            string myDate = "20051010";
            
            myDate=myDate.Insert(4, "/");
            myDate= myDate.Insert(7, "/");
            this.datePicker1.Text = dateSelected;
            //if(this.datePicker1.Text.Contains("-"))
            //    MessageBox.Show("contain -");
            //this.datePicker1.Text = "2014-12-13";
        }        
    }

    //<summary>
    //Entry point class to handle single instance of the application
    //</summary>
    public static class EntryPoint
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Main");
            Console.ReadLine();
            Window1 showWin = new Window1();
            showWin.Show();
            //App app = new App();
            //app.Run();
        }
    }
}
